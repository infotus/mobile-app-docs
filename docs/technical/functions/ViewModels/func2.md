---
title: "Setting Values"
weight: 1
---


# Technical Documentation for `SettingBindingValues`

`SettingBindingValues` is an `ObservableObject` class designed for managing and binding various user settings in a SwiftUI application. It handles background themes, button styles, font styles, and other customizable settings. It also interacts with Firebase to fetch and update user-owned items.

## Enum

### `BG_Theme_Type`
An enum representing the type of background theme:

- `Image`: Represents a background theme that uses an image.
- `Color`: Represents a background theme that uses a color.

## Class

### `SettingBindingValues`
`SettingBindingValues` is an `ObservableObject` that holds various properties related to user settings and customization options. The class includes functionality to update and manage settings such as backgrounds, buttons, and fonts. It also interacts with Firebase to synchronize user data.

#### Properties

- `@Published var backButton: Bool`: Indicates whether the back button is visible.
- `@Published var background: String`: Represents the name of the current background.
- `@Published var backgroundType: String`: Type of the background ("Image" or "Color").
- `@Published var buttonStyleName: String`: Name of the current button style.
- `@Published var buttonStyleBackground: String`: Background style of the button.
- `@Published var imageUrl: String`: URL of the current background image.
- `@Published var bg_color: Color`: Color used for the background.
- `@Published var bg_opacity: Double`: Opacity of the background color.
- `@Published var f_style_name: String`: Name of the current font style.
- `@Published var f_style: Font`: Font used for text.
- `@Published var f_color_name: String`: Name of the current font color.
- `@Published var f_color: Color`: Color used for text.
- `@Published var defaultButton: [String]`: Default button images.
- `@Published var blockedList: [String: String]`: Dictionary of blocked users.
- `@Published var buttonStyleImagesName: [String]`: List of button style image names.
- `@Published var all_background_colorNames: [String]`: List of all background color names.
- `@Published var all_font_colors: [String]`: List of all font color names.
- `@Published var all_color_names_with_colors: [String: Color]`: Dictionary mapping color names to `Color` values.
- `@Published var allEmojiNames: [String]`: List of all emoji categories.
- `@Published var allButtonStyleBackground: [String]`: List of all button style backgrounds.
- `@Published var backgroundImagesName: [String]`: List of background image names.
- `@Published var backgroundImageNameWithLink: [String: String]`: Dictionary mapping background image names to URLs.
- `@Published var buttonStyles: [String]`: List of button styles.
- `@Published var buttonStylesWithLink: [String: String]`: Dictionary mapping button styles to URLs.
- `@Published var allButtons: [[String]]`: List of button image names for each button style.
- `@Published var fontStyles: [String]`: List of font styles.
- `@Published var ownedBackgroundImages: [String: String]`: Dictionary of owned background images.
- `@Published var ownedBackgroundColor: [String: Color]`: Dictionary of owned background colors.
- `@Published var ownedButtonStyles: [String: String]`: Dictionary of owned button styles.
- `@Published var ownedFontColor: [String]`: List of owned font colors.
- `@Published var ownedFontStyles: [String]`: List of owned font styles.
- `@Published var ownedEmojis: [String]`: List of owned emojis.

#### Methods

##### **`getBackgroundType(name: String) -> BG_Theme_Type`**

**Description:** Determines whether the specified background name corresponds to an image or a color.

**Parameters:**

- `name`: The name of the background item.

**Returns:** `BG_Theme_Type` indicating the type of the background.

##### **`changeButtonStyle(name: String)`**

**Description:** Changes the button style based on the specified name.

**Parameters:**

- `name`: The name of the button style to apply.
  
##### **`changeBackgroundTheme(name: String)`**

**Description:** Changes the background theme based on the specified name.

**Parameters:**

- `name`: The name of the background theme to apply.

##### `changeFontColor(name: String)`

**Description:** Changes the font color based on the specified name.

**Parameters:**

- `name`: The name of the font color to apply.

##### `changeFontStyle(name: String)`

**Description:** Changes the font style based on the specified name.

**Parameters:**
- `name`: The name of the font style to apply.

##### `getOwnedItemList()`

**Description:** Fetches the list of items owned by the current user from Firebase and updates local properties accordingly.

**Usage:** This method is used to synchronize the local settings with the user's owned items in Firebase.

#### Usage

This class is typically used in a SwiftUI application to bind user settings to UI components. The `@Published` properties allow for reactive updates in SwiftUI views, ensuring that changes to user settings are immediately reflected in the UI. Methods in this class are used to modify and manage these settings based on user actions or data fetched from Firebase.

