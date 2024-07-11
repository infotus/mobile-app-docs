# WebView

#### Overview

To show that Cheer Supports web content on mobile I used an open-source web browser engine called Webkit. WebKit is a browser engine primarily used in Apple's Safari web browser, as well as all web browsers on iOS and iPadOS. Cheer Supports web content is changing frequently and to keep up with the web content updates webview was the best choice. All scripts related webview is separeated from the others and they under 'Webservices' folder. Folder contain "WebView", "WebViewModel", "APIService" and AccountServiceViewModel script files. 

The WebView struct is a SwiftUI component designed to display web content using WKWebView, which is part of the WebKit framework. It integrates into SwiftUI views to render web pages specified by a URL and provides functionality for observing URL changes, handling navigation, and interacting with JavaScript.

##### Struct: WebView

The WebView struct conforms to UIViewRepresentable, making it compatible with SwiftUI's view hierarchy.
Properties

- url: A String property representing the main URL to be loaded initially.
- webVM: An instance of WebViewModel used to manage state and interactions with the web view.

###### Methods

- makeUIView: Initializes and configures the WKWebView instance. Sets up configuration for media playback and JavaScript interaction permissions. Observes URL changes and updates the webVM's current_url property.

- updateUIView: Updates the WKWebView instance with a new URL when the url property changes.

- makeCoordinator: Creates and returns an instance of the Coordinator class, which acts as the delegate for the WKWebView and handles navigation events.

##### Class: Coordinator

The Coordinator class manages interactions and events within the WKWebView instance.
Properties

- parent: A reference to the parent WebView instance.
- observer: An optional NSKeyValueObservation instance to observe URL changes in the web view.

###### Methods

- webView(_:didFail:withError:): Delegate method called when navigation to a URL fails. Prints the error message.

- webView(_:didFinish:): Delegate method called when web view finishes loading a URL. Prints a success message.

- webView(_:createWebViewWith:for:windowFeatures:): Delegate method to handle creating a new web view for navigation actions that target a new frame.

- webView(_:didReceiveServerRedirectForProvisionalNavigation:): Delegate method called when the web view receives a server redirect during navigation. Prints the redirected URL.

##### Extension: WKWebView

An extension on WKWebView provides additional functionality to create JSON data from a dictionary.
Methods

- createJsonData(for:): Converts a dictionary [String:Any] into a JSON string, removing unnecessary whitespace and newline characters.

##### Usage

To use the WebView component in a SwiftUI view, initialize it with a url and webVM instance. Example usage:
```
struct ContentView: View {
    @StateObject private var webVM = WebViewModel()
    
    var body: some View {
        WebView(url: "https://www.example.com", webVM: webVM)
            .onAppear {
                // Additional setup when the web view appears
            }
    }
}

```

Considerations:

- Ensure proper handling of JavaScript interactions and permissions based on application requirements.
- Monitor for potential memory leaks when using observers and delegates.
- Test thoroughly across different web content to ensure compatibility and responsiveness.

This documentation outlines the structure, functionality, and usage considerations for integrating a web view within a SwiftUI application using the WebView struct.

#### WebViewModel

##### Overview

The WebViewModel.swift file contains the WebViewModel class, which serves as a bridge between SwiftUI components and the WKWebView for managing web content interactions. It includes methods for reloading, navigating, and interacting with local storage within the web view.

##### Class

The WebViewModel class extends NSObject and conforms to ObservableObject and WKNavigationDelegate, facilitating communication between SwiftUI views and the web view.

###### Properties

- current_url: A @Published property that stores the current URL loaded in the web view.
- webView: An optional WKWebView instance. Setting this property assigns the navigation delegate to self.

###### Methods

- reload(): Reloads the current web page.

- goBack(): Navigates back to the previous web page.

- getCurrentURL(): Retrieves the URL of the current web page.

- setLocalStorage(name: id: token: ): Stores user data in the browser's local storage using JavaScript. Converts a dictionary to JSON format and injects it into the local storage.

- getLocalStorage(): Retrieves data from the browser's local storage using JavaScript.

- clearLocalStorage(): Clears all data from the browser's local storage using JavaScript.

##### Delegate Methods

- webView(_:didFail:withError:): Delegate method called when web view navigation fails. Prints the error message if navigation fails.

- webView(_:didFinish:): Delegate method called when web view finishes loading a URL. Handles necessary actions upon successful navigation.

##### Usage

To use WebViewModel in a SwiftUI application, instantiate it and use its methods to interact with the embedded WKWebView.

Example: 

```
struct ContentView: View {
    @StateObject private var webVM = WebViewModel()
    
    var body: some View {
        VStack {
            Text("Current URL: \(webVM.current_url)")
            Button("Reload") {
                webVM.reload()
            }
            Button("Go Back") {
                webVM.goBack()
            }
            Button("Get Local Storage") {
                webVM.getLocalStorage()
            }
        }
        .onAppear {
            // Setup initial web view configuration
            let webView = WKWebView()
            webVM.webView = webView
            
            // Load initial URL
            let initialURL = URL(string: "https://www.example.com")!
            webView.load(URLRequest(url: initialURL))
        }
    }
}

```

##### Considerations

- Ensure proper handling of optional values when accessing webView property.
- Manage JavaScript interactions cautiously, especially with sensitive user data stored in local storage.
- Test thoroughly across different web scenarios to verify functionality and error handling.

This documentation provides an overview of WebViewModel.swift, describing its purpose, properties, methods, and usage within a SwiftUI context. It outlines how to interact with web views and manage local storage effectively.


#### APIService

##### Overview

The Webservice.swift file encapsulates various API request functions and handles corresponding responses for the "Cheer Supports" application. It uses Swift's URLSession and Combine framework for asynchronous networking tasks, ensuring efficient communication with the backend services.

##### Class

The APIService class contains methods for making API requests to different endpoints, processing responses, and handling errors. Each method corresponds to a specific API route within the application.

##### Properties

None.


##### Methods

- getUserAvatar(token:):
    - Route: 195 (User information)
    - Purpose: Retrieves the avatar URL for a user.
    - Throws: PathError.custom, PathError.noData
    - Description: Fetches user avatar details from the server using HTTP GET request and returns the avatar URL as a String.

- getUserProfile(token:):
    - Route: 129 (User profile information)
    - Purpose: Retrieves user profile information, specifically live streaming status.
    - Throws: PathError.noData, PathError.invalidUrl
    - Description: Sends a GET request to fetch user profile data and returns an array of Route129Response objects.

- getLoginDatas(email:password:completion:):
    - Route: 100 (Login)
    - Purpose: Performs user login and retrieves user ID, token, and nickname upon successful authentication.
    - Throws: No direct throws, uses completion handler for AuthenticationError cases.
    - Description: Sends a POST request with login credentials, handles the response asynchronously using URLSession, and provides results through a completion handler.

- checkCurrentPoint(user_id:token:):
    - Route: 198 (Get user current points)
    - Purpose: Retrieves the current cheer coins for a user.
    - Throws: AuthenticationError.custom, PathError.noData
    - Description: Sends a GET request to fetch user's current cheer coins based on user ID and token, returning the amount as a String.

- sendEncodedData(encoded_key:token:completion:):
    - Route: 601 (Decrypt the purchase key)
    - Purpose: Decrypts a purchase key for in-app payment.
    - Throws: PurchaseError.invalidUrl, PurchaseError.invalidKey
    - Description: Sends a POST request to decrypt an encoded key using a token, handling the response asynchronously through a completion handler.

- sendCheerDeductionInformations(user_id:token:quantity:price:platform:item_id:completion:):
    - Route: 602 (Update the Cheer)
    - Purpose: Deducts cheer points upon item purchase in the application.
    - Throws: PathError.custom, PathError.noData
    - Description: Sends a POST request to update cheer points deduction, handling the response asynchronously through a completion handler.

- deleteAccountRequest(user_id:token:):
    - Route: 132 (Account deletion request)
    - Purpose: Sends a request to delete a user account.
    - Throws: No direct throws, prints error message for invalid API URL.
    - Description: Sends a POST request to initiate an account deletion request using user ID and token.

- getFollowListCount(user_id:token:):
    - Route: 196 (Follow list count)
    - Purpose: Retrieves the count of users a particular user is following.
    - Throws: PathError.custom, PathError.noData
    - Description: Sends a GET request to fetch the count of users followed by a specified user, returning a Route196Response object.

- getLastStreaming(user_id:token:):
    - Route: 603 (Last Streaming Date)
    - Purpose: Retrieves the last streaming date for mission reward calculations.
    - Throws: PathError.custom, PathError.noData
    - Description: Sends a GET request to fetch the last streaming date of a user based on user ID and token, returning a Route603Response object.

- getWatchedStreams(user_id:token:):
    - Route: 604 (Watched Live Streaming Dates)
    - Purpose: Retrieves the list of dates a user watched live streams for future features.
    - Throws: PathError.custom, PathError.noData
    - Description: Sends a GET request to fetch the list of dates a user watched live streams, returning an array of Route604Response objects.

- getLastGiftSend(user_id:token:):
    - Route: 605 (Last Gift Items)
    - Purpose: Retrieves information about the last gift item sent by a user.
    - Throws: PathError.custom, PathError.noData
    - Description: Sends a GET request to fetch details about the last gift item sent by a user, returning a Route605Response object.


##### Considerations

- Ensure proper error handling for network requests and API responses.
- Validate inputs (like tokens, IDs) before making API requests.
- Utilize async/await for asynchronous operations where supported to simplify concurrency.
- Test thoroughly across different network conditions and scenarios to ensure robustness.

This documentation provides an overview of Webservice.swift, detailing its purpose, methods, routes, and considerations for effective usage in the "Cheer Supports" application.


#### AccountServiceViewModel

##### Overview

The `AccountServiceViewModel.swift` file serves as a view model in the "Cheer Supports" application, managing user authentication, data retrieval from APIs, and state management for user-related information. It utilizes Swift's Combine framework for reactive programming and asynchronous operations.

##### Class

The `AccountServiceViewModel` class encapsulates methods and properties to facilitate user authentication, data fetching, and management of user session state.

###### Properties

- **`isAuthenticated`**: Tracks whether the user is authenticated.
- **`nick_name`**: Stores the user's nickname.
- **`user_id`**: Stores the user's ID.
- **`iconPath`**: Stores the URL path for the user's avatar.
- **`email`**: Stores the user's email address.
- **`password`**: Stores the user's password.
- **`token`**: Stores the authentication token for API requests.
- **`cheer`**: Stores the user's cheer points.
- **`channel_id`**: Stores the ID of the user's channel.
- **`follow`**: Stores the count of users followed by the current user.

###### Methods

- **`login(email:password:)`**:
    - **Purpose**: Initiates user login using provided email and password.
    - **Throws**: Passes errors from `APIService().getLoginDatas` method.
    - **Description**: Asynchronously fetches user authentication data from the server and updates view model properties upon successful login.

- **`authenticate(email:password:)`**:
    - **Purpose**: Attempts user authentication and returns a boolean indicating success.
    - **Throws**: Passes errors from `login(email:password:)` method.
    - **Description**: Calls `login(email:password:)` and handles authentication errors, returning the current authentication state.

- **`getAvatar()`**:
    - **Purpose**: Retrieves the user's avatar URL path.
    - **Throws**: Handles errors from `APIService().getUserAvatar` method.
    - **Description**: Asynchronously fetches and updates `iconPath` with the user's avatar URL.

- **`getChannelID()`**:
    - **Purpose**: Placeholder method for future implementation.
    - **Description**: Intended for retrieving the user's channel ID, not yet implemented.

- **`logout()`**:
    - **Purpose**: Logs out the user by resetting authentication-related properties.
    - **Description**: Resets `isAuthenticated`, `token`, `user_id`, `email`, `password`, and `iconPath` properties to empty or default values.

- **`checkUserCheerPoints()`**:
    - **Purpose**: Retrieves the user's current cheer points.
    - **Throws**: Handles errors from `APIService().checkCurrentPoint` method.
    - **Description**: Asynchronously fetches and updates `cheer` with the user's current cheer points.

- **`purchaseItem(price:quantity:productName:)`**:
    - **Purpose**: Initiates a purchase transaction for an item.
    - **Parameters**: `price`, `quantity`, `productName` - Details of the item to purchase.
    - **Description**: Asynchronously deducts cheer points from the user upon item purchase and updates `cheer` accordingly.

- **`getFollow()`**:
    - **Purpose**: Retrieves the count of users followed by the current user.
    - **Throws**: Handles errors from `APIService().getFollowListCount` method.
    - **Description**: Asynchronously fetches and updates `follow` with the count of users followed by the current user.

- **`isTodayLastStreamingDate()`**:
    - **Purpose**: Checks if the user streamed live today.
    - **Throws**: Handles errors from `APIService().getLastStreaming` method.
    - **Description**: Asynchronously checks if the user's last streaming date was today using `isToday` method.

- **`todayWatchStreams()`**:
    - **Purpose**: Checks if the user watched any live stream today.
    - **Throws**: Handles errors from `APIService().getWatchedStreams` method.
    - **Description**: Asynchronously checks if the user watched any live stream today using `isToday` method.

- **`lastGift()`**:
    - **Purpose**: Checks if the user sent a gift today.
    - **Throws**: Handles errors from `APIService().getLastGiftSend` method.
    - **Description**: Asynchronously checks if the user sent a gift today using `isToday` method.

- **`formattedDate(jsonDate:)`**:
    - **Purpose**: Converts a JSON-formatted date string to a `Date` object.
    - **Parameters**: `jsonDate` - A date string in JSON format.
    - **Returns**: A `Date` object parsed from the `jsonDate`.

- **`isToday(date:)`**:
    - **Purpose**: Checks if a given date is today.
    - **Parameters**: `date` - The `Date` object to check.
    - **Returns**: `true` if the date is today; otherwise, `false`.

- **`isStillLiveStreamActive()`**:
    - **Purpose**: Checks if the user's live stream is currently active.
    - **Throws**: Handles errors from `APIService().getLastStreaming` method.
    - **Description**: Asynchronously checks if the user's live stream is active today using `isToday` method.

##### Usage Example

Below is an example demonstrating how to use the `AccountServiceViewModel` class:

```swift
let viewModel = AccountServiceViewModel()

// Example: Authenticate user
async {
    do {
        let isAuthenticated = try await viewModel.authenticate(email: "user@example.com", password: "password")
        if isAuthenticated {
            print("User is authenticated!")
            await viewModel.getAvatar()
            await viewModel.checkUserCheerPoints()
            let followCount = await viewModel.getFollow()
            print("User is following \(followCount) users.")
        } else {
            print("Authentication failed.")
        }
    } catch {
        print("Error authenticating: \(error)")
    }
}
```

##### Considerations

- Ensure proper error handling for asynchronous operations and API requests.
- Use Combine framework for reactive updates to UI based on state changes.
- Validate inputs (like email and password) before making API requests.
- Test thoroughly under various network conditions and scenarios to ensure reliability.

This documentation provides an overview of `AccountServiceViewModel.swift`, detailing its purpose, methods, properties, and considerations for effective usage in the "Cheer Supports" application.


