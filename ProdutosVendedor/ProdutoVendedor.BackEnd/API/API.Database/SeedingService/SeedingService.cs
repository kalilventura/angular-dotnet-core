using API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Database.SeedingService
{
    public class SeedingService
    {
        private readonly ApiContext _context;

        public SeedingService(ApiContext context)
        {
            _context = context;
        }

        public void SeedProducts()
        {
            if(_context.Products.Any())
            {
                return;
            }
            else
            {
                Product p1 = new Product("c134tt5", "Sabonete", "Bom para a pele", 05);
                Product p2 = new Product("d145uy7", "Shampoo", "Bom para o cabelo", 10);
                Product p3 = new Product("e123rf5", "Perfume", "Cheiroso", 50);

                try
                {
                    _context.Products.AddRange(p1, p2, p3);
                    _context.SaveChanges();
                }
                catch (Exception error)
                {
                    throw error;
                }
            }
        }

        public void SeedSellers()
        {
            if (_context.Sellers.Any())
            {
                return;
            }
            else
            {
                Seller s1 = new Seller("Kalil", "970401708", 600);
                Seller s2 = new Seller("Carlos", "874556332", 800);

                try
                {
                    _context.Sellers.AddRange(s1, s2);
                    _context.SaveChanges();
                }
                catch (Exception error)
                {
                    throw error;
                }
            }
        }
    }
}
