﻿using RzeczyDoOddania.Models;
using RzeczyDoOddania.ViewModels.Item;

namespace RzeczyDoOddania.Interfaces
{
    public interface ISearchService
    {
        Task<IList<ItemForSearchVM>> GetItems();
        Task<IList<ItemForSearchVM>> GetItemsSearch(string? search);
    }
}
