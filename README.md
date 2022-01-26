# Query++
Query++ is a lightweight non restrictive library to simplify the redundant and boilerplate creation of filters (also now as query strings), the main goal is to optimize the time
on well know operations (comparing values, searching for a certain text, take values from a certain range, etc) without commiting the programmer, to a more query elaborated API mixed with Query++.
Also supports simple ordering with property nesting.

## To clarify the potential uses follow the next domain:

Companies that have products and reviews associated to those products.
Simplified in a ERD:
![Domain ERD](/Assets/Images/ERD.png)

We have an API related with the listing of products which can we queried through names, ids or descriptions, all of them upholded in this class
![Request Without Query++](/Assets/Images/RequestWithoutQuery++.png)

Using this code scenario will possible lead to a controller like this
![Controller Without Query++](/Assets/Images/ControllerWithoutQuery++.png)

It works, does the job, but... it's good enough?
What about maintainability or reading comprehension?

That's where Query++ enters the chat.
Let's reformulate the request class to handle all the expression handling like this
![Request With Query++](/Assets/Images/RequestWithQuery++.png)

Let's take a better look of this class, first the opening definition to implement the library
![Request With Query++ Class Detail](/Assets/Images/RequestWithQuery++ClassDetail.png)

But afterwards we need to bind the request properties with the ones of the entity and don't forget the operation to perform
![Request With Query++ Property Detail](/Assets/Images/RequestWithQuery++PropertyDetail.png)

Good, and now, how about we see our new controller implementing Query++
![Controller With Query++](/Assets/Images/ControllerWithQuery++-2.png)

That's easy to read and understand, but what about the queries with logic not encompassed by the common operators? Well, you still can add your own logic, add your custom expression and let the process continues just as it would have been.

### Defining Restrictions Outside Query++
In first place our request class will have an the extra property called ```HotSell```
![Request With Query++ And An Extra Property](/Assets/Images/RequestWithQuery++AndExtraProperty.png)

And the controller will retrieve the restrictions and append the business rule dependending on the value of the ```HotSell``` property
![Controller With Query++ And An Extra Restriction](/Assets/Images/ControllerWithQuery++AndExtraRestriction.png)

In the end we achieved a more maintainable and readable code focused mainly on the results and not the operations itself with the bonus of a documented class for your teammates, lowering the cost of understanding, maintaining and expanding your application.
