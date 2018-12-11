# Midterm for COMP2084

## By Joel Murphy 200203095

This is the second half of the midterm for COMP2084. It isn't required to type up a readme, but I felt that I needed to because of one question.

4. d.
> Hide the Create, Edit, and Delete links for anonymous users but make these links visible for any authenticated users (i.e. have logged in to the site).  So anonymous users can only view the list of flights and click the Details link to see a flight’s details.  They must log in order to Create, Edit, or Delete any flight data.

I understand what it's asking, but I had to leave for the second half of class and I believe that's when it was taught. Unfortunately, the class recordings leave out this part of authorization (probably the missing part 2 video), so my best guess at it would be something similar to:

`@(AuthorizeAttribute ? Html.ActionLink("Edit", "Edit", new { id = item.FlightId }))
`

or

`@(AuthorizeAttribute ? Html.ActionLink("Edit", "Edit", new { id = item.FlightId }))
`

I wrote this readme, not to try and get marks for something I don't know, but to make sure you see this, Rich, and ask if you could go over this quickly next class.