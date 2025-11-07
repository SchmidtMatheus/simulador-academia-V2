# Decisões de mudanças de Arquitetura 
 
Estou criando este documento para fundamentar algumas decisões que tomei e acabaram mudando (e muito) a estrutura do projeto em relação ao anterior. Quero me adiantar e deixar explicado minha tomada de decisão para as seguintes mudanças: 
 
## 1. Consulta no banco 
No primeiro projeto, por praticidade e curva de aprendizado da linguagem acabei não criando um repositório, e criei as abstractions diretamente dos services o que não é o correto. Agora criei corretamente os repositories de cada entidade e para os services, criei interfaces, separando corretamente a responsabilidade e aumentando a flexibilidade para os testes unitários. 

 

## 2. Migrations na camada de Infraestrutura 

Anteriormente por não saber configurar o projeto, e fazendo por uma primeira vez, criei as migrations no layer de API, agora estou trazendo as migrations para a camada de Infraestrutura. 

 

## 3. Paginação via Query 

Aqui tive um desafio que resultou da implementação do repository. Como anteriormente implementei busca paginada para as buscas que teriam mais resultados no banco, as tasks do tipo “findAll” precisam de parâmetros. 
 
Não posso usar DTO´s no repository por um princípio de dependência na Arquitetura (aqui tive que pesquisar bastante porque o projeto não aceitava), depois de algumas buscas entendi que a camada de infraestrutura não pode depender da camada de aplicação (Repository pattern). Baseado nesses princípios eu expus diretamente o componente da Query a partir do repositório para que o service possa tratar o que for preciso. 
 
**Em node não há essa restrição, o que me demandou uma pesquisa maior para entender o conceito 
 
- [Repository and Query Objects Pattern – StackOverflow](https://stackoverflow.com/questions/29089102/repository-and-query-objects-pattern-how-to-implement-complex-queries)  
- [Repository Pattern em Aplicações .NET – Balta.io](https://blog.balta.io/repository-pattern-em-aplicacoes-net/)



## 4. Testes Unitários

Como nunca tive contato com testes unitários no C#/Visual Studio, pesquisei qual ferramenta de teste seria a mais adequada para projetos dotnet 8, e encontrei o xUnit. No link que deixei abaixo, encontrei um arquivo ensindando a usar o padrão AAA para projetos C#, e foi ele que me guiou a criar os exemplos de falha e sucesso na regra de negócio.

Detalhe que precisei criar uma função para checar se já exisita uma Reserva de Aula, pois o método não permitia chamadas assíncronas em uma lista de memória (tentei usar o métoodo ObterQuery)

- [Testes Unitários: do Mock ao Arrange Act & Assert - Medium](https://medium.com/%40marcio.pcmonzon/testes-unit%C3%A1rios-do-mock-ao-arrange-act-assert-2c5f29bd304c)



## 5. Funcionalidades Removidas

Este projeto é uma V2 com o intuito de utilizar apenas pesquisas no Google para criação e implementação. A criação manual do projeto foi bastante edificante, e consegui dar mais atenção aos processos comuns de criação de um back-end. 
Porém acabou consumindo bastante do meu tempo, e optei por não implementar algumas funcionalidades que havia feito antes, como o histórico de mudança de status da Reserva com motivo de cancelamento.
