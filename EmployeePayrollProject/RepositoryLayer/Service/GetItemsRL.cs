using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RepositoryLayer.Service
{
    public class GetItemsRL : IGetItemsRL
    {


        public List<SelectListItem> GetSalary()
        {
            List<SelectListItem> salaryList = new List<SelectListItem>()
            {
          new SelectListItem {Text="5000",Value="5000" },
          new SelectListItem {Text="10000",Value="10000" },
          new SelectListItem {Text="15000",Value="15000"},
          new SelectListItem {Text="20000",Value="20000"},
          new SelectListItem {Text="25000",Value="25000" },
            };

            return salaryList;
        }

        public List<SelectListItem> GetYear()
        {
            List<SelectListItem> yearList = new List<SelectListItem>()
            {
          new SelectListItem {Text="2000",Value="2000" },
          new SelectListItem {Text="2001",Value="2001" },
          new SelectListItem {Text="2002",Value="2002"},
          new SelectListItem {Text="2003",Value="2003"},
          new SelectListItem {Text="2004",Value="2004" },
              new SelectListItem {Text="2005",Value="2005" },
                  new SelectListItem {Text="2006",Value="2006" },
                      new SelectListItem {Text="2007",Value="2007" },
                          new SelectListItem {Text="2008",Value="2008" },
                            new SelectListItem {Text="2009",Value="2009" },
                              new SelectListItem {Text="2008",Value="2008" },
                               new SelectListItem {Text="2009",Value="2009" },
                                new SelectListItem {Text="2010",Value="2010" },
                                 new SelectListItem {Text="2011",Value="2011" },
                                  new SelectListItem {Text="2012",Value="2012" },
                                   new SelectListItem {Text="2013",Value="2013" },
                                    new SelectListItem {Text="2014",Value="2014" },
                                     new SelectListItem {Text="2015",Value="2015" },
                                      new SelectListItem {Text="2016",Value="2016" },
                                       new SelectListItem {Text="2017",Value="2017" },
                                        new SelectListItem {Text="2018",Value="2018" },
                                         new SelectListItem {Text="2019",Value="2019" },
                                          new SelectListItem {Text="2020",Value="2020" },
                                           new SelectListItem {Text="2021",Value="2021" },
            };

            return yearList;
        }


        public List<SelectListItem> GetMonth()
        {
            List<SelectListItem> monthList = new List<SelectListItem>()
            {
          new SelectListItem {Text="1",Value="1" },
          new SelectListItem {Text="2",Value="2" },
          new SelectListItem {Text="3",Value="3"},
          new SelectListItem {Text="4",Value="4"},
          new SelectListItem {Text="5",Value="5" },
              new SelectListItem {Text="6",Value="6" },
                  new SelectListItem {Text="7",Value="7" },
                      new SelectListItem {Text="8",Value="8" },
                          new SelectListItem {Text="9",Value="9" },
                            new SelectListItem {Text="10",Value="10" },
                              new SelectListItem {Text="11",Value="11" },
                               new SelectListItem {Text="12",Value="12" },
                               
            };

            return monthList;
        }

        public List<SelectListItem> GetDay()
        {
            List<SelectListItem> dayList = new List<SelectListItem>()
            {
          new SelectListItem {Text="1",Value="1" },
          new SelectListItem {Text="2",Value="2" },
          new SelectListItem {Text="3",Value="3"},
          new SelectListItem {Text="4",Value="4"},
          new SelectListItem {Text="5",Value="5" },
              new SelectListItem {Text="6",Value="6" },
                  new SelectListItem {Text="7",Value="7" },
                      new SelectListItem {Text="8",Value="8" },
                          new SelectListItem {Text="9",Value="9" },
                            new SelectListItem {Text="10",Value="10" },
                              new SelectListItem {Text="11",Value="11" },
                               new SelectListItem {Text="12",Value="12" },
                                 new SelectListItem {Text="13",Value="13" },
                                   new SelectListItem {Text="14",Value="14" },
                                     new SelectListItem {Text="15",Value="15" },
                                       new SelectListItem {Text="16",Value="16" },
                                         new SelectListItem {Text="17",Value="17" },
                                           new SelectListItem {Text="18",Value="18" },
                                             new SelectListItem {Text="19",Value="19" },
                                               new SelectListItem {Text="20",Value="20" },
                                                 new SelectListItem {Text="21",Value="21" },
                                                   new SelectListItem {Text="22",Value="22" },
                                                     new SelectListItem {Text="23",Value="23" },
                                                       new SelectListItem {Text="24",Value="24" },
                                                         new SelectListItem {Text="25",Value="25" },
                                                           new SelectListItem {Text="26",Value="26" },
                                                            new SelectListItem {Text="27",Value="27" },
                                                             new SelectListItem {Text="28",Value="28" },
                                                              new SelectListItem {Text="29",Value="29" },
                                                               new SelectListItem {Text="30",Value="30" },
                                                                new SelectListItem {Text="31",Value="31" },
                                                               

            };

            return dayList;
        }

    }
}
