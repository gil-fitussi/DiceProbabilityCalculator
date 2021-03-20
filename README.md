<h2>Dice probability calculator</h2>

Question From - https://www.codingame.com/ide/puzzle/dice-probability-calculator

The program takes an input expression (possibly with dice throws) and must print all possible outcomes along with their probabilities.

The expression is an arithmetic expression with parentheses and the following operators, from highest to lowest precedence:

* (*) multiplication

* (+) and (-) addition and subtraction

* The operands are one of:
n: a decimal positive integer
dn: a 'd' followed by a strict positive number, representing a die throw from 1 to n by a uniform distribution

Examples of expressions:
3*2+5 evaluates to 11
d6: evaluates to an integer from 1 to 6, uniform
d6+d6: represents a double-dice throw
