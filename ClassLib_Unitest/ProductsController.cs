using Microsoft.AspNetCore.Mvc;

namespace ClassLib_Unitest
{
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product != null ? Ok(product) : NotFound();
        }
    }
}
