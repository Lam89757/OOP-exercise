## Summary

This is a class library which uesed to a point-of-sale scanning system that accepts an arbitrary ordering of products ,similar to what would happen at an actual checkout line, then returns the correct total price for an entire shopping cart based on per-unit or volume prices as applicable. 

Here are the products listed by code and the prices to use. There is no sales tax.

| Product Code | Unit Price | Bulk Price        |
| ------------ | ---------- | ----------------- |
| A            | $1.25      | 3 for $3.00       |
| B            | $4.25      |                   |
| C            | $1.00      | $5 for a six-pack |
| D            | $0.75      |                   |

I need to use unit test to check this library. These test cases must be shown to work in program: 

1. Scan these items in this order: ABCDABA Verify that the total price is $13.25

2. Scan these items in this order: CCCCCCC Verify that the total price is $6.00
3. Scan these items in this order: ABCD Verify that the total price is $7.25 