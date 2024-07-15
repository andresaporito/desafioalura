using Desafio.Alura.Domain.Entities;
using Desafio.Alura.Domain.Interfaces.Respositories;
using Desafio.Alura.Domain.Interfaces.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Desafio.Alura.Services.Services
{
    public class AutomationService(ICursoRepository cursoRepository) : IAutomationService
    {
        private ICursoRepository _cursoRepository { get; set; } = cursoRepository;
        public async Task RunAutomation()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            var driver = new ChromeDriver(options);

            try
            {

                driver.Navigate().GoToUrl("https://www.alura.com.br");

                var inputSearch = driver.FindElement(By.XPath("//*[@id=\"header-barraBusca-form-campoBusca\"]"));
                inputSearch.SendKeys("RPA");

                inputSearch.Submit();

                Thread.Sleep(5000);

                var primeiroCurso = driver.FindElement(By.XPath("//*[@id=\"busca-resultados\"]/ul/li[1]/a"));
                primeiroCurso.Click();

                Curso curso = new Curso();

                curso.Titulo = driver.FindElement(By.XPath("/html/body/section[1]/div/div[1]/h1")).Text;

                curso.Professor = driver.FindElement(By.XPath("//*[@id=\"section-icon\"]/div[1]/section/div/div/div/h3")).Text;

                curso.CargaHoraria = driver.FindElement(By.XPath("/html/body/section[1]/div/div[2]/div[1]/div/div[1]/div/p[1]")).Text;

                curso.Descricao = driver.FindElement(By.XPath("/html/body/section[1]/div/div[1]/p[2]")).Text;

                await _cursoRepository.GravarCurso(curso);


            }
            finally
            {

                driver.Quit();
            }
        }

        public async Task<List<Curso>> GetAll()
        {
            var findAll = await _cursoRepository.GetAll();
            return findAll;
        }
    }
}
