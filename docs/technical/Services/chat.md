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

    var body: some View {
        List(msgMenuModel.msgs) { msg in
            ChatRow(chatData: msg)
                .environmentObject(MsgMenuModel())
        }
    }
}
```

- Ensure `AccountServiceViewModel`, `SettingBindingValues`, `MsgMenuModel`, and `FirebaseUserInfoViewModel` are properly initialized and accessible as `EnvironmentObjects`.
- Utilize `AsyncImage` for efficient loading and caching of user profile images.
- Manage state changes (`blocked`, `hidden`, `logo`) asynchronously using `await` to ensure smooth UI updates.
- Handle user interactions (blocking, reporting, message management) securely and efficiently with Firestore database operations.
