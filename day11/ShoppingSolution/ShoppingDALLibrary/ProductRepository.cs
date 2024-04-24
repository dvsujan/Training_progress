﻿using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override Product Add(Product item)
        {
            try
            {
                GetByKey(item.Id);
                throw new ProductAlreadyExistsException();
            }
            catch (ProductNoutFoundException)
            {
                items.Add(item);
                return item;
            }
        }
        public override Product Delete(int key)
        {
                Product product = GetByKey(key);
                if (product != default(Product)) 
                {
                    items.Remove(product);
                }
                return product;
        }

        public override Product GetByKey(int key)
        {
            //Predicate<Product> findProduct =(p)=>p.Id==key;
            //Product product = items.ToList().Find(findProduct);
            //Product product = items.ToList().Find((p) => p.Id == key);
            Product product = items.FirstOrDefault(p => p.Id == key);
            if (product == default(Product))
            {
                throw new ProductNoutFoundException(); 
            }

            return product;
        }

        public override Product Update(Product item)
        {
            Product product = GetByKey(item.Id);
            if (product != null)
            {
                product = item;
            }
            return product;
        }
    }
}
