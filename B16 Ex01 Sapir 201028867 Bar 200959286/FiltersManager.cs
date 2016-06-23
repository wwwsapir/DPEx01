﻿using System;
using System.Collections.Generic;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    using System.Data.OleDb;
    using System.Drawing.Imaging;
    using System.IO;

    public static class FiltersManager
    {
        public static string m_FilePathToSaveFilters = Directory.GetCurrentDirectory() + "/Filters.xml";

        private static readonly List<IFilter> sr_PredefinedFilterList = new List<IFilter>()
                                                              {
                                                                   new Filter(
                                                                      new ColorMatrix(), 
                                                                      "None"),
                                                                  new Filter(
                                                                      new[]
                                                                          {
                                                                              new float[] { 0.33f, 0.33f, 0.33f, 0, 0 },
                                                                              new float[] { 0.59f, 0.59f, 0.59f, 0.59f, 0 },
                                                                              new float[] { 0.11f, 0.11f, 0.11f, 0.11f, 0 },
                                                                              new float[] { 0, 0, 0, 1, 0 },
                                                                              new float[] { 0, 0, 0, 0, 1 }
                                                                          },
                                                                      "GreyScale"),
                                                                  new Filter(
                                                                      new[]
                                                                          {
                                                                              new float[] { -1, 0, 0, 0, 0 },
                                                                              new float[] { 0, -1, 0, 0, 0 },
                                                                              new float[] { 0, 0, -1, 0, 0 },
                                                                              new float[] { 0, 0, 0, 1, 0 },
                                                                              new float[] { 1, 1, 1, 0, 1 }
                                                                          },
                                                                      "Invert"),
                                                                    new Filter(
                                                                    new[]
                                                                        {
                                                                            new float[] { 0.393f, 0.349f, 0.272f, 0, 0 },
                                                                            new float[] { 0.769f, 0.686f, 0.534f, 0, 0 },
                                                                            new float[] { 0.189f, 0.168f, 0.131f, 0, 0 },
                                                                            new float[] { 0, 0, 0, 1, 0 },
                                                                            new float[] { 0, 0, 0, 0, 1 }
                                                                        },
                                                                    "Sepia"),
                                                                    new Filter(
                                                                    new[]
                                                                        {
                                                                            new float[] { 1.5f, 1.5f, 1.5f, 0, 0 },
                                                                            new float[] { 1.5f, 1.5f, 1.5f, 0, 0 },
                                                                            new float[] { 1.5f, 1.5f, 1.5f, 0, 0 },
                                                                            new float[] { 0, 0, 0, 1, 0 },
                                                                            new float[] { -1, -1, -1, 0, 1 }
                                                                        },
                                                                    "Black And White"),
                                                                   
                                                                        new Filter(
                                                                        new[]
                                                                            {
                                                                                new float[] { 0.25f, 0.25f, 0.25f, 0, 0 },
                                                                                new float[] { 0.5f, 0.5f, 0.5f, 0, 0 },
                                                                                new float[] { 0.125f, 0.125f, 0.125f, 0, 0 },
                                                                                new float[] { 0, 0, 0, 1, 0 },
                                                                                new float[] { 0.2f, 0.2f, 0.2f, 0, 1 }
                                                                            },
                                                                        "Ancient"),
                                                                        new Filter(
                                                                        new[]
                                                                            {
                                                                                new float[] { 1.438f, -0.062f, -0.062f, 0, 0 },
                                                                                new float[] { -0.122f, 1.378f, -0.122f, 0, 0 },
                                                                                new float[] { -0.016f, -0.016f, 1.483f, 0, 0 },
                                                                                new float[] { 0, 0, 0, 1, 0 },
                                                                                new float[] { -0.03f, 0.05f, -0.02f, 0, 1 }
                                                                            },
                                                                        "Polaroid") 
                                                                        };


        private static List<IFilter> s_filterList = null;
        private static FilterGroup s_filterGroup = null;

        public static FilterGroup GetFiltersList()
        {
            if (s_filterList == null)
            {
                try
                {
                    s_filterList = GetFilterListFromFile().FilterList;
                }
                catch(Exception)
                {
                    s_filterList = sr_PredefinedFilterList;
                }
            }

            if (s_filterGroup == null)
            {
                s_filterGroup = new FilterGroup(s_filterList, null, "Main");
            }

            return s_filterGroup;
        }

        public static FilterGroup GetFilterListFromFile()
        {
            System.Xml.Serialization.XmlSerializer reader =
               new System.Xml.Serialization.XmlSerializer(typeof(List<IFilter>));

            FileStream file = File.Open(m_FilePathToSaveFilters, FileMode.Open);

            FilterGroup loadedIFilters = reader.Deserialize(file) as FilterGroup;
            file.Close();

            return loadedIFilters;
        }

        public static void SaveFilterListToFile(FilterGroup i_FilterListToSave)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<IFilter>));

            FileStream file = File.Create(m_FilePathToSaveFilters);

            writer.Serialize(file, i_FilterListToSave);
            file.Close();
        }
    }
}
