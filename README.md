![download](https://user-images.githubusercontent.com/128743124/229802068-0ac82dc8-f326-4042-b724-68773d8ac7e3.png)


# Test Scenario 1: Telia login for private customers.

## Test Case 1.1: Valid login for private customer functionality.

## Pre-condition: 
 - Ensure that the user is open page: [https://www.telia.lt/privatiems].
 - The user must have created an account: [https://www.telia.lt/mano/privatiems/sso/registruotis-iveskite-el-pasta].
 
## Test steps: 
            1.1.1 Click on the "Prisijungti" button.
            1.1.2 Click on the "Privatiems prisijungti" button.
            1.1.3 Select Prisijungimo būdas "Su slaptažodžiu".
            1.1.4 Enter valid Email/Telia ID (test.telia142@gmail.com).
            1.1.5 Enter valid password (Testtelia123).
            1.1.6 Press the "Prisijungti" button.
## Expected Result:
            1.1.1 Redirects to login page for private custumers successfully.
            1.1.2 Redirects to login page successfully.
            1.1.3 Login with password successfully selected.
            1.1.4 Username is enetered successfully.
            1.1.5 Password is enetered successfully.
            1.1.6 Redirect to "Mano Telia privatiems" page.   
             
 ## Test Case 1.2: Invalid login with incorrect Email/Telia ID.
 ## Pre-condition: 
  - Ensure that the user is open page: [https://www.telia.lt/privatiems].
  - The user must have created an account: [https://www.telia.lt/mano/privatiems/sso/registruotis-iveskite-el-pasta].
## Test steps: 
            1.2.1 Click on the "Prisijungti" button.
            1.2.2 Click on the "Privatiems prisijungti" button.
            1.2.3 Enter invalid Email/Telia ID (invalid.email@example.com).
            1.2.4 Enter valid password (Testtelia123).
            1.2.5 Press the "Prisijungti" button.
## Expected Result:
            1.2.1 Redirects to login page for private custumers successfully.
            1.2.2 Redirects to login page successfully.
            1.2.3 Error message is displayed for invalid Email/Telia ID.
            1.2.4 User is not redirected to "Mano Telia privatiems" page.

## Test Case 1.3: Invalid login with incorrect password.
## Pre-condition: 
  - Ensure that the user is open page: [https://www.telia.lt/privatiems].
  - The user must have created an account: [https://www.telia.lt/mano/privatiems/sso/registruotis-iveskite-el-pasta].
## Test steps: 
            1.3.1 Click on the "Prisijungti" button.
            1.3.2 Click on the "Privatiems prisijungti" button.
            1.3.3 Enter valid Email/Telia ID (test.telia142@gmail.com).
            1.3.4 Enter invalid password (IncorectPasword123).
            1.3.5 Press the "Prisijungti" button.
## Expected Result:
            1.3.1 Redirects to login page for private custumers successfully.
            1.3.2 Redirects to login page successfully.
            1.3.3 Error message is displayed for incorrect password.
            1.3.4 User is not redirected to "Mano Telia privatiems" page.

## Test Case 1.4: Forgot password functionality.
## Pre-condition:
 - Ensure that the user is open page: [https://www.telia.lt/privatiems].
 - The user must have created an account: [https://www.telia.lt/mano/privatiems/sso/registruotis-iveskite-el-pasta].
## Test steps: 
            1.4.1 Click on the "Prisijungti" button.
            1.4.2 Click on the "Privatiems prisijungti" button.
            1.4.3 Click on the "Pamiršote slaptažodį?" link.
            1.4.4 Enter valid Email/Telia ID (test.telia142@gmail.com).
            1.4.5 Press the "Tęsti" button.
## Expected Result:
            1.4.1 Redirects to login page for private custumers successfully.
            1.4.2 Redirects to login page successfully.
            1.4.3 User is redirected to the password recovery page.
            1.4.4 Email/Telia ID is entered successfully.
            1.4.5 Password recovery instructions are sent to the specified email address.
 
  # Test Scenario 2: Product Buy Flow.
  
  ## Test Case 2.1: Verify that the user can order the product.
  
  ## Pre-condition: 
   -  Ensure that the user has opened the page: [https://www.telia.lt/privatiems].
   ## Test steps:
            2.1.1 Navigate to "E-parduotuvė".
            2.1.2 Open the category "Ausinės".
            2.1.3 Select Apple AirPods Pro (2nd gen) (2022).
            2.1.4 Press the "Užsakyti" button.
            2.1.5 Fill out user data: Vardas = Test, Pavardė = Telia, El. paštas = test.telia@gmail.com, Tel. numeris = +37065586425,.
            2.1.6 Press the "Tęsti" button.
            2.1.7 Verify the address: Gatvė, miestas / kaimas / gyvenvietė = Šilo g., Druskininkų m., Druskininkų sav., Namo numeris = 2.
            2.1.8 Press "Tęsti".
 
  ## Expected Result:
            2.1.1 After pressing, a pop-up table with all product categories appears.
            2.1.2 The user is redirected to the "Ausinės" category.
            2.1.3 The user is redirected to the Apple AirPods Pro (2nd gen) (2022) description.
            2.1.4 The user is redirected to the "Kliento duomenys" page.
            2.1.5 User successfully fills out the "Kliento duomenys" data.
            2.1.6 The user is redirected to the "Pristatymas" page.
            2.1.7 User successfully fills out the "Pristatymas" data.
            2.1.8 The user is redirected to the "Apmokėjimas" page.
            
   # Test Scenario 3: Validate "Akcijos ir naujienos" menu.
   ## Test Case 3.1: Check content & structure for "Telefonai" category.
   
   ## Pre-condition: 
   - Go to a category page: [https://www.telia.lt/privatiems].
  
   ## Test steps:
           3.1.1 Navigate to the "Akcijos ir naujienos" menu.
           3.1.2 Select the "Telefonai" category.
           3.1.3 Check if there is a promotion element containing the alt attribute starting with "Nuolaida".
           3.1.4 Identify the first two elements with an old price.
           3.1.5 Click the "Compare" checkboxes for the two phones with old prices.
           3.1.6 Click on the "Compare" button to initiate the comparison of the two phones.

## Expected Result:
           3.1.1 Akcijos ir naujienos" menu is visible and accessible.
           3.1.2 "Telefonai" category is available and selectable under "Akcijos ir naujienos" menu.
           3.1.3 Promotion element with the alt attribute starting with 'Nuolaida' is present.
           3.1.4 At least two items with an old price are present in the "Telefonai" category under "Akcijos ir naujienos" menu.
           3.1.5 "Compare" checkboxes are clickable for the two selected phones.
           3.1.6 After clicking the "Compare" button, a comparison screen or overlay appears displaying the chosen phones side by side for comparison.
           
   # Test Scenario 4: Service selection.
   ## Test Case 4.1: "Paslaugos" page functionality.
   
   ## Pre-condition: 
   - Ensure that the user is open page: [https://www.telia.lt/privatiems].
   
   ## Test steps:
            4.1.1 Navigate to the "Paslaugos" menu.
            4.1.2 Select the "Telia1" category.
            4.1.3 Click the "Gauti pasiūlymą" button.
            4.1.4 Fill out the form: Name / Surname, Phone, Comment.
            4.1.5 Press the "Gauti pasiūlymą" button.
            
  ## Expected Result:
             4.1.1 After pressing, a pop-up table with service selections appears.
             4.1.2 The user is redirected to a new page.
             4.1.3 The form appears in the pop-up for the user to fill in.
             4.1.4 The form has been successfully filled out.
             4.1.5 The pop-up table closes.
             
   # Test Scenario 5: Search functionality on Telia website.
   ## Test Case 5.1: Basic search functionality
   ## Pre-condition:
   - Ensure that the user is open page: [https://www.telia.lt/privatiems].

   ## Test steps:
            5.1.1 Navigate to the search field.
            5.1.2 Enter a keyword related to products or services (e.g., "Apple iPhone 14 pro").
            5.1.3 Press "Enter" or click on the search button to initiate the search.
            5.1.4 Check if the search results are displayed and if they match the entered keyword.
            5.1.5 Find the specific product "Apple iPhone 14 pro" in the search results and click on it to open the product description page.
  ## Expected Result:
            5.1.1 The search field is present and functional on the website.
            5.1.2 The search results are displayed according to the entered keyword.
            5.1.3 The number of search results, titles, and images match the entered keyword.
            5.1.4 The "Apple iPhone 14 pro" product is found in the search results.
            5.1.5 The product description page for "Apple iPhone 14 pro" is successfully opened. 

