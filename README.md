#  Arman Sahota
#  Assignment: Lond Underground Communt
 # 01/20/2024
# Assignment: London Underground Commute

## Introduction
The London underground recently hired some guy named, WILL, to help build their new ticketing system to hand the number of Riders that ride the Tube everyday. Unfortunetly he was lazy. Not programmer lazy, just lazy. And he built his code so that if more than 100 customers ride in a day, the whole system went down.

YOU are here to fix his shoddy work. You will build your own custom list to replace his list, `WillsList`. What an ego. Your list should expand as it hits nears capacity so that you don't hit capacity at 100 customers.

To show how much better you are then this Will guy, you will also add Linear Search functionality so that the Underground system can easily see which riders started at a particular station or which riders are currently active.

![London Tube Map](Images/LondonTubeMap.PNG)

---

## Detailed Requirments

- Fork the repoisotry ( add your last name to the end of the project)
- Add your name to the top of the project in comments
    ```csharp
        // William Cram
        // Assignment: Lond Underground Communt
        // 01/10/2024
    ```
- Points are lost if you submit your code with compile time errors
- Replace the usage of `WillsList` in the `MainWindow.cs` with your list. You should just have to change the name of YourList.

    ```csharp
        // Top of MainWindow
        public WillsList<Rider> Riders; // Replace this
        public YourList<Rider> Riders; // With your list

        // Bottom of MainWindow
        Riders = new WillsList<Rider>(); // Replace this
        Riders = new YourList<Rider>(); // With this
    ```

If done correctly it should work like normal, but now you can have more than 100 riders.

- Implement the code for your linear searchs in the provided empty method calls.

    ```csharp
        private void OnSearchStation(object sender, RoutedEventArgs e)
        {
            var searchStation = cmbSearchStation.SelectedIndex;
     
            // Enter code here 
        }

        private void OnShowActive(object sender, RoutedEventArgs e)
        {
            // Enter code here 
        }
    ```

### Custom List
- Create a new class for your custom list, it should be generic 
    - ( extra credit if you remember how to make it generic but Type safe to Rider. But can't be Rider only )
    - Custom list should work similar to a regular list object
    - have an internal array
    - have a count property ( which tells how many items are currently in the list, not the same as size of the internal array)
    - Has 2 constructors 
        - ` CustomList()` no parameters, default array size of 10
        - `CustomList(int)` 1 para, int. Choose the initial size of the array.
    - Have a property for count. Getter, no setter
    - Following methods
        - `private void CheckIntegrity()`: 
            when run, checks to see if the current count of elements is over 80% of the capacity of the current internal array. If it is then expand the capacity by 2. Ensure none of the items are lost and that they maintain their location integrity.
        - `public void Add(T)`:  
        Add an object to the end of the list. Make sure to `CheckIntegrity` to make sure you don't get an overflow error.
        - `public void AddAtIndex(T, int)`:  
          Add an item at the selected index. Make sure to maintain object location integrity
        - `public void RemoveAtIndex(int)`:  
            Remove the item at the selected index. Validate to make sure the index is within range. Make sure item location integrity is maintained.
        - `public T GetItem(T)`:  
            A method that gets the item at the selected index. Make sure the method doesn't crash if an invalid index is entered. You can either create a get method, or override the index, `[]`.

        - Inherit from Ienumerable so that you can attach your CustomList to an ItemsSource ( or use with a foreach ). Code is below.

    ```csharp
        public class YourList<T> : IEnumerable<T>
        {

        // ... Code for your Custom List Methods

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < _count; i++)
                {
                    yield return _items[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    ```

### Linear Search

- You can either refactor your list object to have linear search included, or you can create a custom class to assign with Linear Search. 
- Do not build the Linear Search methods into your Main Window.
- Your Linear Search should have the follow methods
    - `public YourList ReturnRidersAtStation(Station or in)`:  
    A linear search that returns all travelers that started at a partciular station
    - `public YourList ReturnAllActiveRiders()`:  
    A linear search that returns a list of all riders currently actively riding.


---

## Specifics

- Rider Class is included. You don't need to do anything specific with this class
- Station enum is included. 
    - 0 indicates a rider is actively riding
    - Any other number is a station
- If your code is working, then you should be able to display over 100 different Riders at one time on the top List View
- Clicking Search you should be able to select a particular station with the drop down and dispaly all riders that started at a particular station in the bottom menu
- Clicking Show Active will display all riders who are currently riding


---

## Rubric for London Underground Commute Assignment

| **Category**                        | **Description**                                                                 | **Points** |
|-------------------------------------|---------------------------------------------------------------------------------|------------|
| **Repository Forking**              | Successfully forking the repository and appending the last name to the project. | 5          |
| **Code Header**                     | Adding name and assignment details as a header comment in the project.          | 5          |
| **Compile-Time Errors**             | No compile-time errors in the submitted code.                                   | 10         |
| **Replacing `WillsList`**           | Correctly replacing `WillsList` with the custom list in `MainWindow.cs`.        | 10         |
| **Linear Search Implementation**    | Proper implementation of linear search methods as specified.                    | 15         |
| **Custom List Creation**            | Developing a new generic custom list class as per requirements.                 | 20         |
| **Custom List Functionality**       | Implementation of all required methods and properties in the custom list.       | 20         |
| **Linear Search Integration**       | Integration of linear search functionality with the list or as a separate class.| 10         |
| **Testing and Validation**          | Successful demonstration of list capacity beyond 100 riders and accurate search functionality.| 5          |

**Total: 100 Points**

