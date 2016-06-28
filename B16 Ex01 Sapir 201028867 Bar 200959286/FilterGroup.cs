using System.Collections.Generic;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    using System;
    using System.Collections;
    using System.Drawing.Imaging;
    using System.Linq;

    public class FilterGroup : IFilter, IEnumerable
    {
        private List<IFilter> m_FiltersList;

        private string m_Name;

        public IFilter Parent { get; set; }

        public ColorMatrix PixelFilter { get; set; }

        public FilterValues FilterValues { get; set; }

        public List<IFilter> FilterList
        {
            get
            {
                return this.m_FiltersList;
            }

            set
            {
                this.m_FiltersList = value;
            }
        }

        public string Name
        {
            get
            {
                return "<< " + this.m_Name + " >>";
            }

            set
            {
                this.m_Name = value;
            }
        }

        // enumerator to traverse the composite structure using DFS Inorder
        public class FilterGroupIterator : IEnumerator<IFilter>
        {
            private IEnumerator<IFilter> m_MainEnumerator;
            private List<IFilter> m_List;
            private Stack<IEnumerator<IFilter>> m_Stack;

            public bool InitialStep { get; set; }

            public FilterGroupIterator(List<IFilter> i_FilterList)
            {
                this.m_List = i_FilterList;
                this.m_MainEnumerator = this.m_List.AsEnumerable().GetEnumerator();
                this.m_Stack = new Stack<IEnumerator<IFilter>>();
                InitialStep = true;
            }

            public void Dispose()
            {
                this.m_Stack = null;
                this.m_List = null;
            }

            public bool MoveNext()
            {
                bool hasNext = true;
                if (!this.m_Stack.Any())
                {
                    if (InitialStep)
                    {
                        InitialStep = false;
                        this.m_MainEnumerator.MoveNext();
                        if (!this.m_MainEnumerator.MoveNext())
                        {
                            hasNext = false;
                        }

                        this.m_Stack.Push(this.m_MainEnumerator);
                        FilterGroup child = this.m_Stack.Peek().Current as FilterGroup;
                        if (child != null)
                        {
                            List<IFilter>.Enumerator childEnumerator = child.m_FiltersList.GetEnumerator();
                            childEnumerator.MoveNext();
                            if (childEnumerator.MoveNext())
                            {
                                this.m_Stack.Push(childEnumerator);
                            }
                            
                            // else:  childnode has no sub-items, so the next item is the childnode itself (DFS Inorder style)
                        }
                    }
                    else
                    {
                        hasNext = false;
                    }
                }
                else
                {
                    if (this.m_Stack.Peek().MoveNext())
                    {
                        FilterGroup nextItem = Current as FilterGroup;
                        while (nextItem != null) 
                        {
                           
                            List<IFilter>.Enumerator childEnumerator = nextItem.m_FiltersList.GetEnumerator();
                            childEnumerator.MoveNext();
                            if (childEnumerator.MoveNext())
                            {
                                this.m_Stack.Push(childEnumerator);
                            }

                            nextItem = Current as FilterGroup;
                        }
                    }
                    else
                    {
                        this.m_Stack.Pop();
                        if (!this.m_Stack.Any())
                        {
                            hasNext = false;
                        }
                    }
                }

                return hasNext;
            }

            public void Reset()
            {
                this.m_Stack.Clear();
                this.m_MainEnumerator = this.m_List.GetEnumerator();
                IEnumerator<IFilter> newEnumerator = this.m_MainEnumerator;
                newEnumerator.MoveNext();
                if (newEnumerator.MoveNext())
                {
                    this.m_Stack.Push(this.m_MainEnumerator);
                }
            }

            public IFilter Current
            {
                get
                {
                    try
                    {
                        return this.m_Stack.Peek().Current;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
        }

        public FilterGroup(List<IFilter> i_Filters, IFilter i_Parent, string i_Name = "Untitled")
        {
            this.m_FiltersList = i_Filters;
            if (i_Parent == null)
            {
                Parent = this;
            }
            else
            {
                Parent = i_Parent;
            }

            m_FiltersList.Insert(0, Parent);
            Name = i_Name;
            PixelFilter = new ColorMatrix();
            FilterValues = new FilterValues();
        }

        // for xml serialization
        public FilterGroup()
        {
        }

        public FilterGroup(List<IFilter> i_List, string i_Name)
        {
            this.m_FiltersList = i_List;
            Parent = this;
            Name = i_Name;
            PixelFilter = new ColorMatrix();
            FilterValues = new FilterValues();
        }

        public void SetFilter(FilterValues i_FilterValues)
        {
            for (int i = 1; i < this.m_FiltersList.Count; i++)
            {
                this.m_FiltersList[i].SetFilter(i_FilterValues);
            }

            FilterValues = i_FilterValues;
        }

        public ColorMatrix GetColorMatrixWithAdjustments()
        {
            return ColorMatrixUtilities.AdjustColorMatrix(PixelFilter, FilterValues);
        }

        public void ApplyFilter()
        {
            for (int i = 1; i < this.m_FiltersList.Count; i++)
            {
                this.m_FiltersList[i].ApplyFilter();
            }

            PixelFilter = ColorMatrixUtilities.AdjustColorMatrix(PixelFilter, FilterValues);
            FilterValues = new FilterValues();
        }

        public IEnumerator GetEnumerator()
        {
            return new FilterGroupIterator(this.m_FiltersList);
        }
    }
}
