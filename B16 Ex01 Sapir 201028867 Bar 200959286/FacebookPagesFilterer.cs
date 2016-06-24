using System;

using FacebookWrapper.ObjectModel;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    class FacebookPagesFilterer
    {
        private readonly Func<Page, bool> r_FilteringStrategyFunction;

        public FacebookPagesFilterer(Func<Page, bool> i_FilteringStrategyFunction)
        {
            r_FilteringStrategyFunction = i_FilteringStrategyFunction;
        }

        public FacebookObjectCollection<Page> FilterPagesCollection(FacebookObjectCollection<Page> i_CollectionToFilter)
        {
            FacebookObjectCollection<Page> filteredLikedPages = new FacebookObjectCollection<Page>();
            foreach (Page likedPage in i_CollectionToFilter)
            {
                if (r_FilteringStrategyFunction.Invoke(likedPage))
                {
                    filteredLikedPages.Add(likedPage);
                }
            }

            return filteredLikedPages;
        }
    }
}
