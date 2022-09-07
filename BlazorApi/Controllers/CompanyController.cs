using BlazorApi.Models;
using BlazorModels; 
using Microsoft.AspNetCore.Mvc;

namespace BlazorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRespository companyRespository;
        public CompanyController(ICompanyRespository companyRespository)
        {
            this.companyRespository = companyRespository;
        }


        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return await companyRespository.GetCompanies();
        }
        [HttpGet("{id}")]
        public async Task<Company?> Get(int id)
        {
            return await companyRespository.GetCompany(id);
        }
        [HttpPost]
        public async Task<Company?> Post(Company company)
        {
            return await companyRespository.SaveCompany(company);
        }

        [HttpPut]
        public async Task<Company?> Put(Company company)
        {
            return await companyRespository.SaveCompany(company);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            companyRespository.DeleteCompany(id);
            return Ok();
        }
    }
}
