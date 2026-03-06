# 📦 Desafio Magazine Luiza – API de Agendamentos

API REST desenvolvida em **.NET** para gerenciamento de agendamentos de envio de mensagens. O sistema permite criar, consultar e remover agendamentos, aplicando regras de domínio para garantir a consistência dos dados.

## Estrutura do projeto

O projeto segue os princípios de **Clean Architecture**, separando as responsabilidades em camadas:

- `Magalu.Domain` - Contém as entidades, interfaces e validações das regras de negócio.
- `Magalu.Application` - Implementa os casos de uso, DTOs e serviços da aplicação.
- `Magalu.Infrastructure` - Gerencia o acesso a dados, persistência e integrações externas.
- `Magalu.API` - Interface de entrada (Controllers) e configuração da injeção de dependência.

## Requisitos

- .NET SDK 6.0+ (Recomendável 8.0).
- Banco de Dados (SQL Server ou In-Memory para testes).
- IDE (VS Code, Visual Studio ou Rider).

> O projeto utiliza **Clean Architecture** para garantir baixo acoplamento e alta coesão entre os módulos.

## Como executar

1. Abra um terminal na pasta raiz do projeto.
2. Restaure as dependências:
   ```bash
   dotnet restore
