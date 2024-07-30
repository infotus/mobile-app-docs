---
title: Request
weight: 1
---

## API's 

`APIService` provides a set of functions to interact with the Cheer Supports API, handling various routes related to user data, login, points, purchases, and more. Each function is asynchronous, using Swift's concurrency features for network operations. There are addinotial APIs beside in APIService class.

### API Endpoints

#### Get User Avatar

- **Route:** `195`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/user/items?type=9`
- **Parameters:** 
    - `token` (String) - Bearer token for authentication

##### Request

```swift
func getUserAvatar(token: String) async throws -> String
```

##### Response

- **Success:** Returns the URL of the user’s avatar.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Unauthorized access
- `500..600`: Server errors
- `PathError.custom`: Custom error message if the response is not valid

#### Get User Profile Information

- **Route:** `129`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/user/channel/mine`
- **Parameters:**
    - `token` (String) - Bearer token for authentication

##### Request

```swift
func getUserProfile(token: String) async throws -> [Route129Response]
```

##### Response

- **Success:** Returns an array of `Route129Response` containing user profile information. Check [this](response.md#route129response) for more details about response.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL or no data
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

#### Login

- **Route:** `100`
- **Method:** `POST`
- **URL:** `https://api.cheer-supports.com/api/v1/liver/login`
- **Parameters:**
    - `email` (String)
    - `password` (String)

##### Request

```swift
func getLoginDatas(email: String, password: String, completion: @escaping (Result<Array<String>, AuthenticationError>) -> Void)
```

##### Response

- **Success:** Array containing user ID, nickname, and token respectively.
- **Failure:** Throws `AuthenticationError` if login fails.

##### Error Handling

- `AuthenticationError.custom`: URL issues
- `AuthenticationError.invalidCredentials`: Invalid credentials or missing data

#### Check Current Points

- **Route:** `198`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/user/point?id={user_id}`
- **Parameters:**
    - `user_id` (String)
    - `token` (String)

##### Request

```swift
func checkCurrentPoint(user_id: String, token: String) async throws -> String
```

##### Response

- **Success:** Returns the user’s current points as a string.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

#### Decrypt Purchase Key

- **Route:** `601`
- **Method:** `POST`
- **URL:** `https://api.cheer-supports.com/api/v1/app/purchase/key/decrypt?encodedkey={encoded_key}`
- **Parameters:**
    - `encoded_key` (String)
    - `token` (String)

##### Request

```swift
func sendEncodedData(encoded_key: String, token: String, completion: @escaping (Result<String, PurchaseError>) -> Void)
```

##### Response

- **Success:** Returns decrypted message.
- **Failure:** Throws `PurchaseError` for issues with the key or decoding.

##### Error Handling

- `PurchaseError.invalidUrl`: URL issues
- `PurchaseError.invalidKey`: Invalid key or decoding issues

#### Deduct Cheer

- **Route:** `602`
- **Method:** `POST`
- **URL:** `https://api.cheer-supports.com/api/v1/app/cheer/deduct`
- **Parameters:**
    - `user_id` (String)
    - `quantity` (Int)
    - `price` (Int)
    - `platform` (String)
    - `item_id` (String)
    - `token` (String)

##### Request

```swift
func sendCheerDeductionInformations(user_id: String, token: String, quantity: Int, price: Int, platform: String, item_id: String, completion: @escaping (Result<Route602Response, PathError>) -> Void)
```

##### Response

- **Success:** Returns `Route602Response` with deduction details. Check [this](response.md#route602response) for more details. 
- **Failure:** Throws `PathError` for issues with request or response.

##### Error Handling

- `PathError.custom`: URL issues
- `PathError.noData`: No data returned
- `PathError.decodingError`: Decoding issues

#### Delete Account Request

- **Route:** `132`
- **Method:** `POST`
- **URL:** `https://api.cheer-supports.com/api/v1/contact`
- **Parameters:**
    - `user_id` (String)
    - `token` (String)

##### Request

```swift
func deleteAccountRequest(user_id: String, token: String)
```

##### Response

- **Success:** No explicit response. Account deletion request is submitted.
- **Failure:** Logs error if URL is invalid.

##### Error Handling

- Logs error for invalid URL

#### Get Follow List Count

- **Route:** `196`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/liver/follow?user_id={user_id}`
- **Parameters:**
    - `user_id` (String)
    - `token` (String)

##### Request

```swift
func getFollowListCount(user_id: String, token: String) async throws -> Route196Response
```

##### Response

- **Success:** Returns `Route196Response` with follow list count. Check [this](response.md#route196response) for more details.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

#### Get Last Streaming Date

- **Route:** `603`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/channel/streaming/date/{user_id}`
- **Parameters:**
    - `user_id` (String)
    - `token` (String)

##### Request

```swift
func getLastStreaming(user_id: String, token: String) async throws -> Route603Response
```

##### Response

- **Success:** Returns `Route603Response` with last streaming date. Check [this](response.md#route603response) for more details.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

#### Get Watched Streams

- **Route:** `604`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/channel/watch/streaming/{user_id}`
- **Parameters:**
    - `user_id` (String)
    - `token` (String)

##### Request

```swift
func getWatchedStreams(user_id: String, token: String) async throws -> [Route604Response]
```

##### Response

- **Success:** Returns an array of `Route604Response` with watched streams.Check [this](response.md#route604response) for more details.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

#### Get Last Gift Sent

- **Route:** `605`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/yell/info/get/{user_id}`
- **Parameters:**
    - `user_id` (String)
    - `token` (String)

##### Request

```swift
func getLastGiftSend(user_id: String, token: String) async throws -> Route605Response
```

##### Response

- **Success:** Returns `Route605Response` with last gift sent details.Check [this](response.md#route605response) for more details.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues


### Firebase API's Endpoints

This function is in the `NotificationManager` observable script. This class is a `@MainActor` class so functions in this class take precedence over class functions. 2 api handled it by NotificationManager 

####  `sendMessageToDevice()`


The `sendMessageToDevice` function is designed to send push notifications to all devices subscribed to the "ios_platform" topic using Firebase Cloud Messaging (FCM). It constructs and sends a notification payload to FCM's messaging endpoint. 

##### Function Signature

```swift
func sendMessageToDevice(msg: String, title: String) async throws
```

##### Parameters

- **`msg`** (`String`): The message body of the notification.
- **`title`** (`String`): The title of the notification.

##### Endpoint

- **URL**: `https://fcm.googleapis.com/v1/projects/cheer-supports-iphone/messages:send`
- **Method**: `POST`

##### Request Headers

- **Content-Type**: `application/json`
- **Authorization**: `Bearer <accessToken>`

##### Request Body

The request body is a JSON object with the following structure:

```json
{
  "message": {
    "topic": "ios_platform",
    "notification": {
      "body": "<msg>",
      "title": "<title>"
    },
    "apns": {
      "headers": {
        "apns-priority": "10"
      },
      "payload": {
        "aps": {
          "alert": {
            "title": "<title>",
            "loc-key": "<msg>"
          },
          "sound": "default"
        }
      }
    }
  }
}
```


1. **Access Token Retrieval**: The function retrieves an access token using `self.getAccessToken()`. This token is used to authorize the request to FCM.
2. **JSON Payload Construction**: Constructs a JSON payload with the message and notification details.
3. **HTTP Request Setup**: Configures the HTTP request with the necessary headers and body.
4. **Sending Request**: Sends the notification via `URLSession.shared.dataTask`.

##### Error Handling

- **Network Errors**: Any network or request errors are logged to the console.
- **Response Handling**: Logs the response if available. The code snippet that handles response status codes is commented out but can be used for further error handling.


For more details about FCM and its notification payload structure, refer to the [Firebase Cloud Messaging Documentation](https://firebase.google.com/docs/cloud-messaging).


### `updateAccessToken()`

The `updateAccessToken()` function asynchronously retrieves a new API access token using a service account. This function is used to refresh or obtain a new token that grants access to various services and APIs.

#### Method Declaration
```swift
func updateAccessToken() async
```

#### Description
This method performs the following steps:

1. Defines the scope required for the API access.
2. Prepares the service account credentials in JSON format.
3. Initializes a `ServiceAccountTokenProvider` with the credentials and scope.
4. Attempts to obtain an access token.
5. Updates the `accessToken` property with the new token if successful, or logs any errors encountered.

#### Parameters
This function does not take any parameters.

#### Return Type
This function does not return any value.

#### Detailed Steps

**Define Scope and Credentials**:

  - `scope`: An array of strings specifying the scopes needed.
  - `json`: An array containing the service account credentials in JSON format.

**Serialize JSON Data**:
  
  - Convert the `json` object to `Data` using `JSONSerialization`.

**Initialize Token Provider**:
   
  - Create an instance of `ServiceAccountTokenProvider` with the JSON data and scope.

**Obtain Access Token**:

  - Call the `withToken` method on the `client` instance.
  - Handle any errors encountered during the token retrieval.

**Update Token**:
    
  - If no errors are encountered, update the `accessToken` property with the new token.

**Error Handling**:
    
  - Print error messages if exceptions occur during JSON serialization or token retrieval.

#### Error Handling

**JSON Serialization Errors**:

  - Errors during the conversion of the JSON object to `Data` are caught and logged.

**Token Retrieval Errors**:
  
  - Errors encountered while retrieving the token are handled within the completion handler of `withToken`.


#### Notes

- The `accessToken` property should be declared in the class where this function is used.
- Ensure that the `ServiceAccountTokenProvider` and its methods (e.g., `withToken`) are correctly implemented and handle tokens as expected.
- The `scope` and `json` variables need to be properly configured based on the specific API requirements and service account credentials.

#### Dependencies

- Ensure you have the necessary imports and dependencies for handling JSON serialization and asynchronous tasks.
- The `ServiceAccountTokenProvider` class must be correctly defined and accessible within your project.



### ServiceAccountTokenProvider

The `ServiceAccountTokenProvider` class is used to manage and provide OAuth 2.0 tokens for service accounts. It constructs and sends a JWT (JSON Web Token) to the OAuth 2.0 token endpoint to obtain an access token. This class relies on service account credentials and RSA private keys for authentication.

#### Class: `ServiceAccountTokenProvider`

##### Properties

- **`token`** (`Token?`): Optional property to hold the token object once it's retrieved.
- **`credentials`** (`ServiceAccountCredentials`): Holds the service account credentials.
- **`scopes`** (`[String]`): The scopes required for the token.
- **`rsaKey`** (`RSAKey`): RSA key used to sign the JWT.

##### Initializers

**`init?(credentialsData: Data, scopes: [String])`**

  Initializes the provider with service account credentials and required scopes.

  **Parameters:**

  - `credentialsData`: Data containing the service account credentials in JSON format.
  - `scopes`: Array of strings representing the scopes required for the token.
  
  **Returns:**

  - An optional `ServiceAccountTokenProvider` instance.

**`init?(credentialsURL: URL, scopes: [String])`**

   Initializes the provider with service account credentials loaded from a URL and required scopes.

  **Parameters:**

  - `credentialsURL`: URL pointing to a JSON file containing the service account credentials.
  - `scopes`: Array of strings representing the scopes required for the token.
  
  **Returns:**

  - An optional `ServiceAccountTokenProvider` instance.

##### Methods

**`withToken(_ callback: @escaping (Token?, Error?) -> Void) throws`**

  Requests a new OAuth 2.0 token by sending a JWT to the token endpoint.

**Parameters:**

  - `callback`: A closure that is called with the resulting token or an error.
  
  **Throws:**

  - Errors may be thrown during JWT encoding or HTTP request execution.
  
  **Returns:**

  - This method does not return a value directly. Instead, the result is passed to the callback.

#### Internal Structures

##### `ServiceAccountCredentials`

Represents the service account credentials required for authentication.

**Properties:**

- `CredentialType`: Type of credential (e.g., "service_account").
- `ProjectId`: Google Cloud project ID.
- `PrivateKeyId`: ID of the private key.
- `PrivateKey`: The private key used to sign the JWT.
- `ClientEmail`: Email associated with the service account.
- `ClientID`: Client ID for the service account.
- `AuthURI`: URI for authentication.
- `TokenURI`: URI for token exchange.
- `AuthProviderX509CertURL`: URL for the authentication provider's X.509 certificate.
- `ClientX509CertURL`: URL for the client's X.509 certificate.

**Coding Keys:**
  
  - Mapped to JSON fields in the service account credentials JSON.


For further details about JWT, OAuth 2.0, and service account credentials, refer to the [Google Cloud documentation](https://cloud.google.com/docs/authentication/getting-started) and [JWT specifications](https://jwt.io/introduction/).


#### Error Types

##### Path Error

- `custom(errorMessage: String)`: Custom error with a message
- `noData`: No data received from the server
- `invalidUrl`: Invalid URL or endpoint
- `decodingError`: Error decoding the response

##### Authentication Error

- `custom(errorMessage: String)`: Custom authentication error
- `invalidCredentials`: Invalid credentials provided

##### Purchase Error

- `invalidUrl`: Invalid URL for purchase decryption
- `invalidKey`: Invalid key provided
- `decoding_error`: Error decoding the decryption response
