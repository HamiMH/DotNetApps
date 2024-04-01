using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Domain.Items;

public class Item
{
    public delegate bool FilterFunc(int id);
}

