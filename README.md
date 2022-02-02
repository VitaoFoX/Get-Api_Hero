<h2 align="center">
  Get Api Hero
</h2>

## Projeto
Get Api Hero tem como objetivo de extrair informações da API pública (https://akabab.github.io/superhero-api/) e retornar algumas chamadas.
A aplicação irá ser executada em: http://localhost:8080/

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

GET => `/powerstat/{powerstat}` Irá retornar os 5 primerios hérois de acordo com o Powerstat escolhido. Parâmetros válidos: intelligence, strength, speed, durability, power e combat. Exemplos:

`/powerstat/speed`
```json
[
  {
    "id": 12,
    "name": "Air-Walker",
    "speed": "100"
  },
  {
    "id": 42,
    "name": "Ardina",
     "speed": "100"
  }
]
```

`/powerstat/durability`
```json
[
  {
    "id": 631,
    "name": "Stardust",
    "durability": "100"
  },
  {
    "id": 5,
    "name": "Abraxas",
     "durability": "100"
  }
]
```


### Algumas tecnologias utilizadas:
* ASP Net Core 6
* Linq
* RestSharp
* AutoMapper


