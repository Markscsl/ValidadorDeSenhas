# 🔐 Validador de Senhas em C#

Aplicação de console desenvolvida em **C#** para validação de senhas a partir de um conjunto de regras de negócio.

O principal objetivo do projeto é demonstrar uma implementação que **não interrompe a validação ao encontrar o primeiro erro**. Todas as regras são verificadas e, caso existam múltiplas violações, o usuário recebe todos os motivos em uma única resposta.

## 🎯 Objetivo

Construir um programa capaz de:

* Receber uma senha informada pelo usuário;
* Validar a senha conforme regras previamente definidas;
* Identificar **todos os critérios não atendidos**;
* Retornar um resultado estruturado contendo a validade da senha e seus respectivos erros;
* Permitir múltiplas tentativas através de um loop de interação;
* Encerrar a aplicação através de um comando de saída.

## 📋 Regras de Validação

Para ser considerada válida, a senha deve atender **a todos** os critérios abaixo:

| # | Regra              | Critério                                                                 |
| - | ------------------ | ------------------------------------------------------------------------ |
| 1 | Tamanho mínimo     | Pelo menos 8 caracteres                                                  |
| 2 | Tamanho máximo     | No máximo 20 caracteres                                                  |
| 3 | Letra maiúscula    | Pelo menos 1 caractere entre `A-Z`                                       |
| 4 | Letra minúscula    | Pelo menos 1 caractere entre `a-z`                                       |
| 5 | Dígito numérico    | Pelo menos 1 número entre `0-9`                                          |
| 6 | Caractere especial | Pelo menos 1 caractere entre `! @ # $ % ^ & * ( ) - _ + =`               |
| 7 | Espaços em branco  | Não pode conter espaços                                                  |
| 8 | Sequências óbvias  | Não pode conter `123`, `abc` ou `senha`, ignorando maiúsculas/minúsculas |

## 🧠 Comportamento da Validação

O projeto utiliza dois comportamentos diferentes durante a validação.

### Entrada nula ou vazia

Entradas como:

```text
null
""
"   "
```

devem ser tratadas imediatamente, retornando uma mensagem específica, como:

```text
Senha não pode ser nula ou vazia.
```

Nesse cenário, as demais regras **não são executadas**.

### Senha processável

Quando a entrada possui conteúdo, todas as regras são avaliadas independentemente.

Por exemplo, para uma senha que não possui letra maiúscula e também possui menos de 8 caracteres, o sistema deve retornar os dois problemas:

```text
Senha inválida.

Erros encontrados:
- A senha deve possuir no mínimo 8 caracteres.
- A senha deve conter pelo menos uma letra maiúscula.
```

Dessa forma, o usuário consegue corrigir todos os problemas de uma única vez.

## 🏗️ Estrutura do Resultado

A validação deve ser separada da apresentação no console.

O resultado pode ser representado por uma estrutura contendo:

```text
ÉVálida
Erros
```

Onde:

* `ÉVálida` indica se a senha atende a todas as regras;
* `Erros` contém as mensagens referentes às regras violadas.

Essa abordagem permite reutilizar a lógica de validação em outros contextos, sem acoplá-la diretamente ao `Console`.

## 🔄 Fluxo da Aplicação

O programa funciona continuamente até que o usuário informe o comando de saída:

```text
Digite uma senha: MinhaSenha123!

Senha inválida.

Erros encontrados:
- A senha não pode conter a sequência "123".

Digite uma senha: MinhaSenha@123

Senha inválida.

Erros encontrados:
- A senha não pode conter a sequência "123".

Digite uma senha: MinhaSenha@2026

Senha válida!

Digite uma senha: sair

Programa encerrado.
```

O comando `sair` é reconhecido independentemente de letras maiúsculas ou minúsculas:

```text
sair
SAIR
Sair
SaIr
```

## 🛡️ Robustez

A aplicação deve garantir que nenhuma entrada fornecida pelo usuário provoque uma exceção não tratada.

O programa deve sempre resultar em um fluxo controlado:

* Senha válida → mensagem de sucesso;
* Senha inválida → lista de erros;
* Entrada nula/vazia → mensagem específica;
* Comando `sair` → encerramento;
* Qualquer outra entrada → processamento normal da validação.

## 🛠️ Tecnologias

* **C#**
* **.NET**
* Aplicação **Console**
* Expressões regulares (`Regex`), quando aplicável
* Princípios de **separação de responsabilidades**

## 📁 Organização sugerida

```text
PasswordValidator/
│
├── Models/
│   └── ValidationResult.cs
│
├── Services/
│   └── PasswordValidator.cs
│
└── Program.cs
```

### Responsabilidades

**`PasswordValidator`**

Responsável exclusivamente pelas regras de validação da senha.

**`ValidationResult`**

Representa o resultado da validação, contendo o status e os erros encontrados.

**`Program`**

Responsável pela interação com o usuário, leitura das entradas e apresentação dos resultados no console.

## 🚀 Como executar

### Pré-requisitos

* .NET SDK instalado.

Verifique a instalação com:

```bash
dotnet --version
```

### Executando o projeto

Clone o repositório:

```bash
git clone <URL_DO_REPOSITORIO>
```

Entre na pasta do projeto:

```bash
cd PasswordValidator
```

Execute:

```bash
dotnet run
```

## 📌 Critérios técnicos demonstrados

Este projeto foi desenvolvido com foco em alguns conceitos importantes de desenvolvimento:

* Validação completa sem *short-circuit* das regras de negócio;
* Tratamento explícito de entradas nulas e vazias;
* Acúmulo de múltiplos erros;
* Separação entre regra de negócio e apresentação;
* Criação de um resultado reutilizável;
* Loop de interação com o usuário;
* Comparação case-insensitive;
* Tratamento robusto das entradas;
* Organização de responsabilidades entre as classes.

## 📄 Licença

Este projeto foi desenvolvido para fins de estudo e demonstração de conceitos de **C#**, validação e organização de código.
