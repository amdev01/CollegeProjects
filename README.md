# StringCalculator
My college project that takes the whole equation as a string
and **magically** works it out rather than inputing all the numbers
separately what most **CLI** Calculators do. Similar to the compute()
function from DataTable class. The aim is to replace that function
with my OSS code.

Current state (WIP):
* Supports simple mathematical calculations
	* Addition
	* Subtraction
	* Multiplication
	* Division
	* Modulus
* Somehow optimes validation

## TODO

- [ ] Follow BODMAS
- [ ] Add more mathematical operations
	- [ ] Powers, roots, trigonometry
	- [ ] Algebra
- [ ] Handle larger equations
- [ ] Optimise the algorithm and validation

**I still hate c# to the bits and would rather do all this in C/C++**

## How to run this program on Linux?

First of all you need to instal [.NET](https://www.microsoft.com/net/core) <= Follow this link for setup instructions
Then run the following in the terminal

    ~$ git clone https://github.com/MyczkowskiAdam/StringCalculator
    ~$ cd StringCalculator
    ~$ dotnet run

That's it, your calculator should be running now!


