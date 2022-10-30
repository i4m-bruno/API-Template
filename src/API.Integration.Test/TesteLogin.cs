using System.Threading.Tasks;
using Api.Integration.Test;
using Xunit;

namespace API.Integration.Test
{
    public class TesteLogin : BaseIntegration
    {
        [Fact]
        public async Task Teste_Login()
        {
            await AdicionarToken();
        }
    }
}
