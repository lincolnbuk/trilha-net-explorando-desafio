namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("Não é possível cadastrar hóspedes antes de cadastrar a suíte.");
            }

            // Verificar se a capacidade da suíte comporta a quantidade de hóspedes
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lançar exceção específica caso ultrapasse a capacidade
                throw new InvalidOperationException("Quantidade de hóspedes maior que a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes cadastrados
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("Não é possível calcular o valor da diária sem uma suíte cadastrada.");
            }

            // Cálculo base: dias reservados * valor da diária da suíte
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra de desconto: 10% para reservas com 10 ou mais dias
            if (DiasReservados >= 10)
            {
                valor *= 0.90m; // aplica desconto de 10%
            }

            return valor;
        }
    }
}