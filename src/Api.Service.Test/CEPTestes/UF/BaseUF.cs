using System;
using System.Collections.Generic;
using API.Domain.Dtos.UF;

namespace API.Service.Test.CEPTestes
{
    public class BaseUF
    {
        public static string Nome { get; set; }
        public static string Sigla { get; set; }
        public static Guid IdUf { get; set; }
        public UfDto UfDto { get; set; }
        public List<UfDto> listaUfDto { get; set; }

        public BaseUF()
        {
            IdUf = Guid.NewGuid();
            Sigla = Faker.Address.UsState().Substring(1,3);
            Nome = Faker.Address.UsState();

            listaUfDto = new List<UfDto>();
            for (int i = 0 ; i < 10; i ++)
            {
                var item = new UfDto {
                    Id = Guid.NewGuid(),
                    Sigla = Faker.Address.UsState().Substring(1,3),
                    Nome = Faker.Address.UsState()
                };

                listaUfDto.Add(item);
            }

            UfDto = new UfDto {
                    Id = IdUf,
                    Sigla = Sigla,
                    Nome = Nome
                };
        }
    }
}
