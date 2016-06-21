# Milaneze.ComparadorDeStrings
Biblioteca utilizada para comparação de strings. Exemplo: comparação entre endereços.

Escrito em C# com o Visual Studio 2015 Community.

NuGet: https://www.nuget.org/packages/Milaneze.ComparadorDeStrings/

```
PM> Install-Package Milaneze.ComparadorDeStrings
```

## Exemplo 1
```
ComparadorEndereco comparador = new ComparadorEndereco();
double porcentagemMatch
	= comparador.CompararLogradouro(
		logradouro1: "Avenida 24 de Fevereiro",
		logradouro2: "Avenida Vinte e Quatro de Feverero"); // faltou o "i" em fevereiro

Console.WriteLine("% Match: {0}", porcentagemMatch); // % Match: 93,61 >> pela falta do "i" em fevereiro
```

## Exemplo 2
```
Endereco endereco1 = new Endereco(
	cidade: "São Paulo",
	estado: "SP",
	logradouro: "Avenida 23 de Maio",
	numero: "110");

Endereco endereco2 = new Endereco(
	cidade: "Sao Paulo", // sem ~ (til)
	estado: "SP",
	logradouro: "Avenida Vinte e Três de Maio", // número por extenso
	numero: "110");


IComparadorEndereco comparador = new ComparadorEndereco(
	porcentagemMinimaMatchLogradouro: 90,
	porcentagemMinimaMatchCidade: 90,
	substituicoesLogradouro: new List<SubstituicaoLogradouro>()
	{
		new SubstituicaoLogradouro(
			de: "Avenida",
			para: "Av"),
		new SubstituicaoLogradouro(
			de: "Av.",
			para: "Av")
	});

IMatchEndereco matchEndereco = comparador.Comparar(endereco1, endereco2);


Console.WriteLine(
	matchEndereco.MatchTotal
	? "Endereços iguais." // esse será o resultado mostrado
	: "Endereços diferentes.");
```

## Exemplo 3
```
IComparadorEndereco comparador = new ComparadorEndereco(
	porcentagemMinimaMatchLogradouro: 90,
	porcentagemMinimaMatchCidade: 90,
	substituicoesLogradouro: new List<SubstituicaoLogradouro>()
	{
		new SubstituicaoLogradouro(
			de: "Avenida",
			para: "Av"),
		new SubstituicaoLogradouro(
			de: "Av.",
			para: "Av")
	});


Endereco endereco1 = new Endereco(
	cidade: "São Paulo",
	estado: "SP",
	logradouro: "Avenida 23 de Maio",
	numero: "110");

Endereco endereco2 = new Endereco(
	cidade: "Sao Paulo", // sem ~ (til)
	estado: "SP",
	logradouro: "Avenida Vinte e Três de Maio", // número por extenso
	numero: "110");


IMatchEndereco matchEndereco = endereco1.Comparar(endereco2, comparador);


Console.WriteLine(
	matchEndereco.MatchTotal
	? "Endereços iguais." // esse será o resultado mostrado
	: "Endereços diferentes.");
```

## Diagrama de Classes
![alt tag](https://raw.githubusercontent.com/ericmilaneze/Milaneze.ComparadorDeStrings/master/Solution/ClassDiagram.png)