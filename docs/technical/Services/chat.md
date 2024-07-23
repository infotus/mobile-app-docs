---
title: In App Chat
weight: 2
---

# In App Chat

This chat feature is available to all app users who have an account, enabling them to participate in conversations. The service also offers user support through this platform. In the future, we intend to provide a comprehensive manual covering the usage of the chat functionality, how to request support via chat, and guidelines for chat etiquette. There are four scripts directly related to this service: MsgMenuModel.swift, ChatRow.swift, GlobalChatView.swift, and EmojiListView.swift.

### MsgMenuModel

The `MsgMenuModel` class manages messaging functionality within an app, integrating Firestore for database operations and SwiftUI for user interface updates.

#### Properties

- **txt**: A published property to store text input for messages.
- **userAvatar**: A published property representing the avatar URL of the current user.
- **imageUrlPath**: A published property holding the path to an image's download URL.
- **msgs**: A published array of `MsgModel` objects, storing messages fetched from Firestore.
- **image_is_ready**: A published boolean indicating whether an image is ready for display.
- **msg_data**: A published `MsgModel` instance used for storing new message data.
- **msg_Index**: An index used for managing message operations.
- **showLevel**: A boolean flag indicating whether to display the user's level.

#### Initialization

The initializer (`init()`) initializes the `MsgMenuModel` instance by calling `readAllMsgs()` to fetch existing messages from Firestore.

#### Methods

- **alertView(title:message:)**: Creates and returns a UIAlertController with a given title and message. Includes a default "OK" action.

- **readAllMsgs()**: Sets up a snapshot listener on the "Msgs" collection in Firestore to listen for changes (additions, modifications, removals) to messages. Updates the `msgs` array accordingly.

- **writeMsg(path:text:user:name:iconPath:uuid:)**: Writes a new message to the Firestore database using data provided. Clears `txt` and `imageUrlPath` after successful write.

- **uploadImageToStorage(image:completion:)**: Uploads an image to Firebase Storage, resizes it to fit within a 500x500 pixel boundary, and returns the download URL upon successful upload.

- **resizeImage(image:targetSize:)**: Resizes a given UIImage to a specified target size.

- **fetchAvatar()**: Fetches the avatar URL (`iconPath`) of the user from Firestore. Updates `userAvatar` on the main thread.

- **hideBlockedUserMessages(uuid:)**: Filters out messages from `msgs` where the `uuid` matches the blocked user's `uuid`.

- **hideMessage(data:index:)**: (Currently not used due to async bug) Removes a message at a specified index and inserts updated data at the same index.

- **hideFromTheList(index:)**: Removes a message from `msgs` at a specified index.

- **showInTheList(data:index:)**: Inserts a message into `msgs` at a specified index.

#### Usage

1. **Initialization**:
   ```swift
   let model = MsgMenuModel()
   ```
   Initializes the model, triggering the retrieval of existing messages from Firestore.

2. **Message Handling**:
   ```swift
   model.writeMsg(path: imagePath, text: messageText, user: userID, name: userName, iconPath: userAvatarPath, uuid: messageUUID)
   ```
   Writes a new message to Firestore with the specified parameters.

3. **Image Upload**:
   ```swift
   model.uploadImageToStorage(image: selectedImage) { imageURL in
       // Handle image upload completion
   }
   ```
   Uploads an image to Firebase Storage and retrieves its download URL upon completion.

4. **Avatar Fetching**:
   ```swift
   model.fetchAvatar()
   ```
   Retrieves the current user's avatar URL from Firestore.


### ChatRow

The `ChatRow` struct represents a SwiftUI view used for displaying chat messages within an app, integrated with Firebase Firestore and SDWebImageSwiftUI for image handling.

#### Properties

- **loginVM**: An `EnvironmentObject` of type `AccountServiceViewModel` for managing user authentication.
- **settings**: An `EnvironmentObject` of type `SettingBindingValues` providing app settings.
- **msgData**: An `EnvironmentObject` of type `MsgMenuModel` handling message-related data.
- **userInfoVM**: An `EnvironmentObject` of type `FirebaseUserInfoViewModel` managing user information and interactions.
- **imageManager**: An `ObservedObject` of type `ImageManager` for managing image loading and cancellation.
- **chatData**: A `MsgModel` object representing the chat message data to be displayed.
- **image_isReady**: A `@State` variable indicating if an image is ready for display.
- **showReportReason**: A `@State` variable controlling the visibility of the report reason dialog.
- **blocked**: A `@State` variable indicating if the user associated with the chat message is blocked.
- **hidden**: A `@State` variable indicating if the chat message is hidden.
- **logo**: A `@State` variable holding the URL path for the sender's level logo.
- **isAnimating**: A `@State` variable controlling animation states.

#### Components

- **AsyncImage**: Loads and displays user profile images asynchronously.
- **NickName**: Custom view displaying user nicknames.
- **AnimatedImage**: Loads and displays animated images from URLs.
- **ChatBubble**: Custom shape for chat message bubbles.

#### Functionality

- **Message Display**: Displays chat messages with appropriate styling based on the sender (`current_user` or guest).
- **User Interaction**: Provides context menus for blocking users, reporting messages, showing/hiding messages, and deleting own messages.
- **Image Handling**: Supports loading and displaying images within chat messages.
- **User Profile**: Displays user profile information including avatar and nickname.
- **Dynamic Updates**: Updates message visibility (`hidden`), blocked user status (`blocked`), and sender's level logo (`logo`) dynamically.

#### Usage

```swift
struct ContentView: View {
    @EnvironmentObject var msgMenuModel = MsgMenuModel()
    ...
    ...
    ...


    var body: some View {
        List(msgMenuModel.msgs) { msg in
            ChatRow(chatData: msg)
                .environmentObject(MsgMenuModel())
                ...
                ...
                ...
        }
    }
}
```

### GlobalChatView

The `GlobalChatView` SwiftUI component is designed for a chat interface that supports sending messages, uploading images, and selecting emojis. It integrates Firebase for authentication and messaging, and utilizes various environment objects for managing app state and user data. 

#### Dependencies
- **SwiftUI**: Provides the framework for building user interfaces.
- **BottomSheet**: Enables bottom sheet functionality for showing emojis.
- **SDWebImageSwiftUI**: Handles asynchronous image loading and caching.
- **Firebase**: Backend service for user authentication and real-time messaging.

#### State Management
- **@EnvironmentObject**:
  - `msgData`: Manages chat messages and state.
  - `loginVM`: Handles user authentication and session management.
  - `userInfoVM`: Manages user information from Firebase.
  - `settings`: Manages app settings such as theme and colors.
  - `envManager`: Manages environment-specific settings.
  - `missionVM`: Handles mission-related tasks and rewards.
  - `notification`: Manages notifications to other devices.
  - `url_params`: Manages selected URL for emojis.

- **@AppStorage**:
  - `background_theme`, `text_color`, `text_style`: Persist app settings like background theme and font styles.

- **@State**:
  - `showAlert`, `scrolled`, `showLogOutOptions`, `showImagePicker`, `image`, `emoji_url`, `showLogInAlert`, `isNotLoggedIN`, `message`, `showOptional`, `imagePreview`, `showingOverlay`, `isPlaying`: Local state variables for managing UI state and user interaction.

- **@FocusState**:
  - `isFocused`, `focus`: Manages focus state for text fields (`CustomTextField`).

#### Views and Components
- **Main Layout**:
  - Uses `GeometryReader` to dynamically adjust layout based on screen size.
  - Embeds components in a `VStack` for vertical stacking.

- **Chat Section**:
  - Displays chat messages in a `ScrollView` with `ScrollViewReader` for message scrolling.
  - Messages are dynamically updated using `onChange` and `task`.

- **Image and Emoji Preview**:
  - Displays selected images and emojis as overlays using `overlay`.

- **Bottom Section**:
  - Contains buttons for adding images (`showImagePicker`) and emojis (`showingOverlay`).
  - Uses `CustomTextField` for message input.

- **Top Section**:
  - Custom toolbar (`toolbar`) with back button, chat title, and user avatar.
  - Utilizes `fullScreenCover` for image picker and `sheet` for sign-in view.

#### Interaction and Logic
- **Authentication and State Management**:
  - Handles authentication status and user data using Firebase.
  - Manages app settings and theme changes dynamically.

- **Messaging and Notifications**:
  - Allows users to send messages with optional images and emojis.
  - Sends notifications to other devices using Firebase Cloud Messaging.

#### Previews and Utility Components
- **MessagePlaceholder**: Placeholder view for message input.
- **CustomTextField**: Customized text field component with support for emojis.

#### Extensions and Utilities
- **UIApplication Extension**:
  - Utility method (`hideKeyboard`) to dismiss the keyboard.



### EmojiListView

The `EmojiListView` SwiftUI component is designed to display and select emojis for use in a chat interface. It provides a horizontal scroll view for emoji categories and a grid view for displaying individual emojis within a selected category. The component supports dynamic loading of emoji images using SDWebImageSwiftUI for improved performance.

#### Dependencies
- **SwiftUI**: Provides the framework for building user interfaces.
- **SDWebImageSwiftUI**: Handles asynchronous image loading and caching for smooth emoji display.
- **UIApplication Extension**: Provides utility to retrieve the current active UI window.

#### State Management
- **@Binding**:
  - `showing`: Manages the visibility of the emoji list view.
  - `play`: Controls the animation state of emojis.
  
- **@EnvironmentObject**:
  - `url_params`: Manages URL lists for emojis.
  - `settings`: Manages app settings and emoji ownership.

- **@ObservedObject**:
  - `imageManager`: Manages the loading and cancelation of emoji images.

- **@State**:
  - `owned`: Tracks whether the user owns a specific emoji category.
  - `item`: Tracks the currently selected emoji category.
  - `link`: Stores the URL link of selected emojis.

#### Views and Components
- **Emoji Type Preview**:
  - Horizontal `ScrollView` showing preview images of emoji categories.
  - Each category image is loaded dynamically from a predefined list of URLs.

- **Emoji List Preview**:
  - Vertical `ScrollView` displaying individual emojis in a grid layout (`LazyVGrid`).
  - Emojis are loaded dynamically based on the selected category (`selected_url_list`).

#### Interaction and Logic
- **Emoji Selection**:
  - Tapping an emoji category updates the displayed emoji list (`selected_url_list`).
  - Emojis are displayed in a grid and can be selected for use in the chat interface.

- **Emoji Ownership**:
  - Lock icon overlay indicates emojis that the user does not own (`!settings.ownedEmojis.contains(...)`).

#### Utility and Extensions
- **UIApplication Extension**:
  - `currentUIWindow()`: Retrieves the current active UI window, useful for handling UI interactions or transitions.

