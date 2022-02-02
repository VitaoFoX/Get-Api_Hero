<h2 align="center">
  Get Api Hero
</h2>

## Projeto
Get Api Hero tem como objetivo de extrair informações da API pública (https://akabab.github.io/superhero-api/) e retornar algumas chamadas.

GET => `/` Irá retornar todos os hérois no formato:

```json
[
  {
    "id": 1,
    "name": "A-Bomb"
  },
  {
    "id": 2,
    "name": "Abe Sapien"
  },
  {
    "id": 3,
    "name": "Abin Sur"
  }
]
```

GET => `/powerstat/{powerstat}` Irá retornar os 5 primerios hérois de acordo com o Powerstat escolhido. Parâmetros válidos: intelligence, strength, speed, durability, power e combat.



### Algumas tecnologias utilizadas:
* ASP Net Core 6
* Linq
* RestSharp
* AutoMapper


