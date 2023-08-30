namespace SenorBarbero.Enums
{
    public class GlobalEnums
    {
        /// <summary>
        /// Perfil do usuário (0 - Administrador / 1 - Cliente)
        /// </summary>
        public enum Profile : short
        {
            Admin = 0,
            Client = 1
        }

        public enum SocialNetwork : short
        {
            Instagram = 0,   // Ideal para mostrar fotos dos cortes, estilos e ambientes da barbearia.
            Facebook = 1,    // Para promoções, eventos, e interação com os clientes.
            YouTube = 2,     // Vídeos tutoriais, mostrando o processo de corte, dicas de estilo, etc.
            TikTok = 3,      // Conteúdo de vídeo curto e criativo, mostrando transformações rápidas, tendências, etc.
            Pinterest = 4,   // Inspiração para estilos de cabelo e barba.
            WhatsApp = 5,    // Comunicação direta com os clientes, agendamentos, promoções exclusivas.
            LinkedIn = 6,    // Mais orientado para o networking e possíveis parcerias com fornecedores ou outros negócios.
            Twitter = 7      // Atualizações rápidas, promoções e interação direta com os seguidores.
        }
    }
}
