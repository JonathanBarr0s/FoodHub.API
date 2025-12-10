<div align="right">

  ![.NET](https://img.shields.io/badge/.NET-10.0-blueviolet)
  ![API Status](https://img.shields.io/badge/status-online-success)
  ![Docker](https://img.shields.io/badge/docker-ready-blue)
  ![Swagger](https://img.shields.io/badge/Swagger-Enabled-brightgreen)
  ![Environment](https://img.shields.io/badge/environment-production-red)

</div>

 <h1 align="center">FoodHub.API</h1>


## Descrição Geral

A **FoodHub API** é uma aplicação desenvolvida em **ASP.NET Core**, projetada para gerenciar restaurantes, pratos e pedidos. Ela fornece endpoints para criação, consulta e atualização de dados.

🔗 **Acesse a API em produção:**

<div align="center">

👉  **https://foodhub-api-q7dx.onrender.com**  👈


</div>

###### *Nota: Esta API pode levar até 50 segundos para inicializar na primeira requisição. Isso ocorre porque ela está hospedada no plano gratuito do Render, que hiberna a aplicação quando fica inativa.*

---

<br>

## Sumário

- [Tecnologias Utilizadas](#1-tecnologias-utilizadas)
- [Arquitetura](#2-arquitetura)
- [Como Rodar](#3-como-rodar)
- [Endpoints da API](#4-endpoints-da-api)
- [Utilizando Postman](#5-utilizando-postman)
- [Acompanhe Meu Trabalho](#6-acompanhe-meu-trabalho)

<br>

## 1. Tecnologias Utilizadas

- ASP.NET Core 10
- Entity Framework Core
- PostgreSQL
- AutoMapper
- FluentValidation
- Docker
- Swagger
- Postman
- Render

<br>

## 2. Arquitetura

A arquitetura da API é baseada em camadas. Abaixo estão as principais:

### **2.1 Services**

Na pasta `Services/`, ficam as regras de negócio da API. Eles garantem:

* Regras e validações além do básico.
* Orquestração entre repositórios.
* Consistência dos dados.
* Evitar duplicar lógica entre controllers.


### **2.2 Domain**

Na pasta `Domain/`, ficam as **entidades de negócio** como `User`, `Restaurant`, `Dish`, `Order` e `OrderItem`.
Elas representam exatamente como os dados existem e se relacionam no banco.

### **2.3 DTOs**

Na pasta `Dtos/`, cada fluxo (criação, atualização, detalhe, listagem) possui seu próprio DTO para evitar vazamento de dados do domínio e aumentar a segurança da API.

### **2.4 AutoMapper**

A pasta `Mappings/` contém o perfil do AutoMapper para lidar com a conversão entre entidades e DTOs, removendo código repetitivo e facilitando a evolução das entidades.

### **2.5 Validações (FluentValidation)**

Localizados em `Services/Validators/`, validam todas as entradas:

* Verificação de regras.
* Garantia de consistência dos dados antes de chegar ao banco.
* Prevenção de erros de negócio.

### **2.6 Docker**

O projeto inclui:

* `Dockerfile` (construção da imagem).
* `docker-compose.yml` (API + PostgreSQL Local).

<br>

## 3. Como Rodar

A API pode ser executada de diferentes maneiras dependendo do seu ambiente. Abaixo estão as três formas recomendadas:

### 3.1 Render (online, já hospedado)

A maneira mais simples é acessar a API diretamente no ambiente publicado:

🔗 **API rodando no Render:** *https://foodhub-api-q7dx.onrender.com*

Não é necessário instalar nada, o Swagger já estará disponível para testes imediatamente após acessar o link.

###### *Nota: Esta API pode levar até 50 segundos para inicializar na primeira requisição. Isso ocorre porque ela está hospedada no plano gratuito do Render, que hiberna a aplicação quando fica inativa.*

### 3.2 Rodar com Docker (localmente)

Para rodar a API dentro de containers Docker, basta seguir os passos:

1. Baixe deste repositório **somente** o arquivo `docker-compose.yml`.
2. Suba a API e o banco Postgres com Docker Compose executando o comando abaixo no PowerShell, no mesmo diretório do arquivo `docker-compose.yml` que você baixou:

```bash
docker compose up -d
```

O Compose irá:

- Baixar a imagem da API do Docker Hub.
- Criar o container do Postgres.
- Subir os dois containers conectados em uma rede interna.
- Aplicar automaticamente as migrations do banco.

3. Acesse o Swagger para testar os endpoints:


[http://localhost:8080/index.html](http://localhost:8080/index.html)

###### *Nota: não é necessário ter Visual Studio ou PostgreSQL local instalado.*

### 3.3 Rodar via Visual Studio (modo desenvolvedor)

#### **Pré-requisitos recomendados**

* .NET 10 SDK.
* Visual Studio 2026.
* PostgreSQL.

#### **Passo a passo**

1. Abra a solução `FoodHub.API.slnx`.
2. Garanta que a connection string do *appsettings.Development.json* aponte para um banco local.
3. Pressione **F5** para rodar. Na primeira execução, o Entity Framework executará automaticamente todas as migrations, criando todo o banco de dados estruturado.
4. Acesse o Swagger para testar os endpoints:

[http://localhost:8080/index.html](http://localhost:8080/index.html)

<br>

## 4. Endpoints da API

Abaixo estão todos os endpoints disponíveis na API **FoodHub**, separados por recurso:


### 4.1 Usuários (`UserController`)

<div align="center">

| Método     | Rota             | Descrição                     |
| ---------- | ---------------- | ----------------------------- |
| **GET**    | `/User`      | Retorna todos os usuários     |
| **GET**    | `/User/{id}` | Retorna um usuário pelo ID    |
| **POST**   | `/User`      | Cria um novo usuário          |
| **PUT**    | `/User/{id}` | Atualiza um usuário existente |
| **DELETE** | `/User/{id}` | Exclui um usuário             |

</div>

### 4.2 Restaurantes (`RestaurantController`)

<div align="center">

| Método     | Rota                   | Descrição                      |
| ---------- | ---------------------- | ------------------------------ |
| **GET**    | `/Restaurant`      | Retorna todos os restaurantes  |
| **GET**    | `/Restaurant/{id}` | Retorna um restaurante pelo ID |
| **POST**   | `/Restaurant`      | Cria um restaurante            |
| **PUT**    | `/Restaurant/{id}` | Atualiza um restaurante        |
| **DELETE** | `/Restaurant/{id}` | Exclui um restaurante          |

</div>

### 4.3 Pratos (`DishController`)

<div align="center">

| Método     | Rota             | Descrição             |
| ---------- | ---------------- | --------------------- |
| **GET**    | `/Dish`      | Lista todos os pratos |
| **GET**    | `/Dish/{id}` | Detalhes de um prato  |
| **POST**   | `/Dish`      | Cria um novo prato    |
| **PUT**    | `/Dish/{id}` | Atualiza um prato     |
| **DELETE** | `/Dish/{id}` | Remove um prato       |

</div>

### 4.4 Pedidos (`OrderController`)

<div align="center">

| Método     | Rota                       | Descrição                                                       |
| ---------- | -------------------------- | --------------------------------------------------------------- |
| **GET**    | `/Order`               | Retorna todos os pedidos com detalhes                           |
| **GET**    | `/Order/{id}`          | Retorna um pedido específico                                    |
| **POST**   | `/Order` | Cria um novo pedido   |
| **PUT**   | `/Order/{id}` | Adiciona itens a um pedido existente |
| **DELETE** | `/Order/{id}`          | Exclui um pedido                                                |

</div>

<br>

## 5. Utilizando Postman

Você pode testar todos os endpoints da API utilizando o **Postman**, importando dois arquivos na pasta `/Postman/` deste repositório, sendo: 

`FoodHub.API.postman_collection` → contém todos os endpoints organizados por recursos.

`FoodHub.API Environment.postman_environment` → armazena as variáveis de ambiente.

### 5.1 Como importar a coleção no Postman

1. Abra o Postman.
2. Clique em **Import** (canto superior esquerdo).
3. Arraste e solte o arquivo `FoodHub.API.postman_collection` para dentro do pop-up do Postman.
4. Clique em **Continue** → **Import**.
5. Faça o mesmo processo para `FoodHub.API Environment.postman_environment`.

O Postman irá gerar automaticamente:

* Todas as rotas organizadas por pastas (Users, Restaurants, Dishes, Orders)
* Todos os métodos (GET, POST, PUT, DELETE)
* Corpo das requisições (JSON) prontos para uso

### 5.2 URLs para importar a API

Abaixo estão as URLs conforme o ambiente que você deseja consumir. Altere em Environments > FoodHub.API Environment.

#### 5.2.1 Render (produção)

Use esta URL para importar e testar a API hospedada no Render:

```
https://foodhub-api-q7dx.onrender.com
```

#### 5.2.2 Via Docker

Se você estiver rodando a API em um container Docker local, o Swagger ficará acessível através de:

```
http://localhost:8080/swagger/v1/swagger.json
```

#### 5.2.3 Localmente via Visual Studio

Quando você roda o projeto localmente, o Swagger fica disponível em:

```
https://localhost:7209/index.html
```

### 5.3 Testando as rotas

Após importar a coleção, basta:

* Selecionar o método desejado
* Alterar o JSON no corpo da requisição (somente quando necessário)
* Clicar em **Send**

<br>

## 6. Acompanhe Meu Trabalho

Me encontre em outras redes:

- **Docker Hub:** [hub.docker.com/u/jonathanbarr0s](https://hub.docker.com/u/jonathanbarr0s)
- **LinkedIn:** [linkedin.com/in/jonathansbarros/](https://www.linkedin.com/in/jonathansbarros/)