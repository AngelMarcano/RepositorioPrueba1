using InventoryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDAL.Repos
{
    public class ArticleRepo : BaseRepo<table_articles>
    {
        public override List<table_articles> GetAll() => Context.table_articles.Include("table_stores").OrderBy(x => x.name).ToList();
    }
}
