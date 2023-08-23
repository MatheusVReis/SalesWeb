using SalesWebMvc.Data;
using SalesWebMvc.Models;
namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
            //Acessar o db atraves da variavel _context chamando a classe Seller e convertendo para lista com o .ToList();
        }
        public void Insert(Seller obj)
        {
         
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
