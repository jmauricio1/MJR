using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Astronomical_Learning.DAL;

namespace Astronomical_Learning.Controllers
{
    public class SearchController : Controller
    {
        private ALContext db = new ALContext();

        // GET: Search
        [HttpGet]
        public ActionResult SearchPage(string searchQuery)
        {
            //searchQuery = "su";

            if (searchQuery == null)
            {
                searchQuery = "";
            }


            string dataBaseSearchQuery = searchQuery.ToLower();

            var keywordList = db.SearchKeywords.ToArray();

            int keywordListSize = keywordList.Count();

            List<string> validSearches = new List<string>();

            for(int i = 0; i < keywordListSize; i++)
            {
                if((keywordList[i].Name.ToLower()).Contains(searchQuery.ToLower()))
                {
                    validSearches.Add(keywordList[i].Name);
                    Debug.WriteLine("{0} = {1} is true", searchQuery, keywordList[i].Name);
                }
                else
                {
                    Debug.WriteLine("{0} = {1} is false", searchQuery, keywordList[i].Name);
                }
            }

            //  var keyword = db.SearchKeywords.Where(x => x.Name == dataBaseSearchQuery).Select(y => y.Id).First();
            var keywords = db.SearchKeywords.Where(x => validSearches.Contains(x.Name)).Select(y => y.Id);
            //var pagesList = db.KeywordRelations.Where(x => x.KeywordId == keyword).Select(y => y.PageId);
            var pagesList = db.KeywordRelations.Where(x => keywords.Contains(x.KeywordId)).Select(y => y.PageId);
            var pages = db.SitePages.Where(x => pagesList.Contains(x.Id));

            ViewBag.pagesList = pages;
            ViewBag.search = searchQuery;

            return View();

           
        }
    }
}