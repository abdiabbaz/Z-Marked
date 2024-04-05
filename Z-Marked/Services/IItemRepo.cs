﻿using Z_Marked.Model;

namespace Z_Marked.Services
{
    public interface IItemRepo
    {
        Item Create(Item item);
        Item Delete(Item item);
        Item GetItem(int id);
        string ToString();
        Item Update(int id, Item item);
    }
}