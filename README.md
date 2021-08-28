# controleDeEstoque

# Instruções para execução

# Backend
1. Abra o arquivo .sln no Visual Studio
2. Ajuste a Connection String para a local da sua máquina no arquivo appSettings.json
3. No Console do Gerenciador do pacotes, mude o projeto padrão para DTI.Data e Execute o comando 'EntityFrameworkCore\Update-Database'

# FrontEnd
1. Abra a pasta dti-app no CMD e execute o comando 'npm i' e aguarde o fim do processo;
2. Execute o Comando 'ng s';


# Decisões

Migrations: Utilizei a estratégia de Code-First para facilitar a criação do banco de dados para quem for rodar a aplicação

EntityFrameworkCore: Foi utilizado, a fim de deixar o código com uma manutenção mais fácil e uma leitura mais clara também
