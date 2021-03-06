
This is an exercise helping you to learn Test-Driven Development. Your task is to test-drive a function that filters, sorts and paginates a bunch of data. In this case the data concerns horses.

One of the challenges of this exercise is to design suitable test data. There is some sample data provided which you can use as a starting point. Feel free to modify it as needed.

There is also a sample test case provided which is not finished. Feel free to re-design it as you wish. It may not be a good starting test or be correct.

There is a function in the horse backend marked with 'TODO' statements. This function should filter, sort and paginate an arbitrary table of horse data, as specified. You can change anything about the code, except for the signature of this function. It will be called by a front-end component which expects exactly this signature.

Note on data size and performance:

* Assume the table data will have no more than 50 000 rows and 100 columns, and will easily fit into available memory space.
* Assume you will filter on a maximum of 100 columns
* Assume you will only sort on one column
* Assume the pagination is for page sizes of anything from 1 to 500 rows.

**Use Test-Driven Development!**

# More information

The client of this function will be displaying the table data on a web page.
The client expects all the data to be strings so that it is easy to display.

The client of this function will make sure that all the parameters to the
FilterSortPaginateTable function are correct and will not throw exceptions.
This means that the class will not need to perform any error checking or handling.

The totalRows value found in PaginatedTable is the total number of table rows
after the original table was filtered. This allows the client to know whether
there is another page of data to be requested.
