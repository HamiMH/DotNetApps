using BlazorApp.Application.Repository.Common;
using BlazorApp.Domain.Items;
using BlazorApp.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Application.Repository.Specific;

internal class RepositoryItem : RepositoryBase<Item>, IRepositoryItem
{
    public RepositoryItem(DbContext context) : base(context)
    {
    }

    public override IEnumerable<Item> Filter(Item entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Item> Filter(Item.FilterFunc filterFunc)
    {
        throw new NotImplementedException();
    }
}
