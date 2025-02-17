---
title: "Resources"
weight: 1
---


# Resources

## Horizontal Tab
A SwiftUI `View` that displays a horizontal tab bar.

The `CustomHorizontalTabView` is a SwiftUI component designed to display a horizontally scrollable tab bar. It supports custom tab titles and optional icons, allowing users to switch between different tabs with smooth animations. The component adjusts its layout based on whether the tabs are fixed-width or flexible.


### Struct Definitions

#### `Tab`

A simple struct representing a tab in the `CustomHorizontalTabView`.

##### Properties
- `icon`: An optional `Image` that represents the tab's icon.
- `title`: A `String` that specifies the tab's title.

```swift
struct Tab {
    var icon: Image?
    var title: String
}
```

#### `CustomHorizontalTabView`

A SwiftUI `View` that displays a horizontal tab bar.

##### Properties
- `fixed`: A `Bool` that determines whether tabs should have fixed widths (default: `true`).
- `tabs`: An array of `Tab` objects that define the tabs to be displayed.
- `geoWidth`: A `CGFloat` representing the width available for each tab when `fixed` is `true`.
- `selectedTab`: A `Binding` to an `Int` that tracks the index of the currently selected tab.



## `MinusPlusButton`

This script provides a SwiftUI component, `MinusPlusButton`, designed for incrementing and decrementing a bound integer value. It also enforces a maximum value limit of 99. The component uses environment values to bind and observe changes to the value.


### Environment Key: `AmountUnit`

#### Purpose

Defines a custom environment key for binding an integer value, allowing the value to be shared and observed across different views.

#### Definition

```swift
private struct AmountUnit: EnvironmentKey {
    static let defaultValue: Binding<Int> = .constant(0)
}
```

- **`defaultValue`**: The default binding value is set to `0`.

### Extension: `EnvironmentValues`

#### Purpose

Extends `EnvironmentValues` to include the custom `AmountUnit` binding, enabling access to this binding in SwiftUI views.

#### Extension

```swift
extension EnvironmentValues {
    var amountUnit: Binding<Int> {
        get { self[AmountUnit.self] }
        set { self[AmountUnit.self] = newValue }
    }
}
```

- **`amountUnit`**: Provides a computed property to get and set the `AmountUnit` environment value.

### SwiftUI View: `MinusPlusButton`

#### Purpose

A SwiftUI view that includes two buttons (for increment and decrement) and a `TextField` to display and edit an integer value bound through the environment.

#### Properties

- **`@Environment(\.amountUnit)`**: A binding to the integer value that is observed and updated by this view.


#### UI Components

**Buttons**: 

- The minus button decreases the `amountUnit` value by 1 if it is greater than 0.
- The plus button increases the `amountUnit` value by 1 if it is less than 99. If it reaches 99, it remains at that value.

**TextField**:

- Displays the current value of `amountUnit`.
- Uses a `NumberFormatter` to format the integer value.
- On submission, if the value exceeds 99, it is set to 99.

#### Behavior

- **Decrement Button**: Reduces the value bound to `amountUnit` if it is greater than 0.
- **Increment Button**: Increases the value bound to `amountUnit` if it is less than 99. If it reaches 99, it stays at that value.
- **TextField**: Ensures the displayed value does not exceed 99 upon user input.



## `CustomButtonStyle`

The `CustomButtonStyle` is a SwiftUI `ButtonStyle` that allows for the customization of button appearance and behavior. It supports setting button color, size, and provides a visual scaling effect when the button is pressed.

A struct conforming to `ButtonStyle`, which customizes the appearance and animation of a button.

### Properties

- **`color`**: A `Color` that defines the background color of the button.
- **`width`**: A `CGFloat` that specifies the width of the button.
- **`height`**: A `CGFloat` that specifies the height of the button.


### Definition

```swift
struct CustomButtonStyle: ButtonStyle {
    var color: Color
    var width: CGFloat
    var height: CGFloat

    func makeBody(configuration: Configuration) -> some View {
        configuration.label
            .padding(5)
            .frame(width: width, height: height)
            .font(.system(size: 20).bold())
            .background(color)
            .foregroundColor(.white)
            .clipShape(Capsule())
            .cornerRadius(10)
            .scaleEffect(configuration.isPressed ? 0.85 : 1)
            .animation(Animation.easeIn(duration: 0.4), value: 0.2)
    }
}
```

### Method

- **`makeBody(configuration:)`**: A required method for conforming to the ButtonStyle protocol in SwiftUI. It creates and returns a view that represents the style of a button, based on the current configuration.
- **`configuration`**: Provides context for the button’s current state, including whether it is pressed.

#### View Modifiers Applied

- **`padding(5)`**: Adds padding around the button content.
- **`frame(width:height:)`**: Sets the button's width and height.
- **`font(.system(size: 20).bold())`**: Applies a bold font of size 20 to the button's label.
- **`background(color)`**: Sets the button's background color.
- **`foregroundColor(.white)`**: Sets the text color of the button's label to white.
- **`clipShape(Capsule())`**: Clips the button to a capsule shape.
- **`cornerRadius(10)`**: Adds rounded corners with a radius of 10 to the button.
- **`scaleEffect(configuration.isPressed ? 0.85 : 1)`**: Scales down the button to 85% of its size when pressed, providing a visual feedback.
- **`animation(Animation.easeIn(duration: 0.4), value: 0.2)`**: Applies an easing in animation with a duration of 0.4 seconds for the scale effect.


## `KeyboardObserver`

The `KeyboardObserver` class monitors the keyboard's height and updates a published property accordingly. It conforms to the `ObservableObject` protocol, allowing SwiftUI views to react to changes in keyboard height.

A class that observes keyboard visibility and height changes, updating a published property to reflect the current keyboard height.

### Properties

**`@Published var keyboardHeight: CGFloat`**: 

- Represents the current height of the keyboard. Initialized to a default value based on a percentage of the screen height (`UIScreen.main.bounds.height * 0.39`).

### Initializer

**`init()`**:

- Calls `listenForKeyboardNotifications()` to start observing keyboard notifications.

### Methods

**`private func listenForKeyboardNotifications()`**:

- Registers for keyboard notifications (`UIResponder.keyboardDidShowNotification`).
- Updates `keyboardHeight` when the keyboard appears, using the height from the keyboard's frame obtained from the notification.


#### Notes

- **Default Value**: The default keyboard height is set to 39% of the screen's height.
- **Notification Handling**: Only updates the `keyboardHeight` when the keyboard is shown. If you need to handle keyboard hiding, consider adding a listener for `UIResponder.keyboardDidHideNotification`.



## `ChatBubble`

The `ChatBubble` struct defines a custom shape for a chat bubble in SwiftUI. It customizes the shape's corners based on the sender of the message (`myMsg`), creating a distinct appearance for incoming and outgoing messages.

A struct conforming to the `Shape` protocol, used to create a chat bubble with customizable rounded corners.

### Properties

**`var myMsg: Bool`**:

- A boolean indicating whether the message is sent by the current user (`true` for my message, `false` for received message). Determines which corners of the chat bubble are rounded.

### Implementation

```swift
func path(in rect: CGRect) -> Path {
    let path = UIBezierPath(roundedRect: rect, byRoundingCorners: [.topLeft, .topRight, myMsg ? .bottomLeft : .bottomRight], cornerRadii: CGSize(width: 15, height: 15))
    
    return Path(path.cgPath)
}
```

### Methods

**`func path(in rect: CGRect) -> Path`**:

- Creates a `Path` representing the chat bubble's shape.
- Uses `UIBezierPath` to define the rounded rectangle with specific corners rounded based on the `myMsg` property.
- The corners are rounded as follows:
    - **Top Left and Top Right**: Always rounded.
    - **Bottom Left**: Rounded if `myMsg` is `true`.
    - **Bottom Right**: Rounded if `myMsg` is `false`.

