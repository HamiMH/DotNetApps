using BlazorApp.Application.Repository.Common;
using BlazorApp.Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Application.Repository.Specific;

public interface IRepositoryItem : IRepository<Item>
{
    IEnumerable<Item> Filter(Item.FilterFunc filterFunc);
}
