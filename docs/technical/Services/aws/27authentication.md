# Authentication

## SignInViewModel

### Overview

The `SignInViewModel` class manages the user interface and network interactions for the sign-in process in the Cheer Supports application. This documentation provides an overview of its structure, functionality, and usage.

### Class Structure

<!-- ```swift
//
//  SignInViewModel.swift
//  Cheer Supports
//
//  Created by kabutoyuri on 2023/06/28.
//

import Foundation
import Combine

final class SignInViewModel: ObservableObject {
    // Published properties for reactive UI updates
    @Published var email = ""
    @Published var password = ""
    
    @Published var hasError = false
    @Published var isSigningIn = false
    
    // Computed property to determine if sign-in is allowed
    var canSignIn: Bool {
        !email.isEmpty && !password.isEmpty
    }
    
    // Function to initiate the sign-in process
    func signIn() {
        guard !email.isEmpty && !password.isEmpty else {
            return
        }
        
        // Create URLRequest for sign-in API endpoint
        var request = URLRequest(url: URL(string: "https://api.cheer-supports.com/api/v1/liver/login")!)
        request.httpMethod = "POST"
        
        // Encode email and password for Basic Authentication
        let authData = (email + ":" + password).data(using: .utf8)!.base64EncodedString()
        request.addValue("Basic \(authData)", forHTTPHeaderField: "Authorization")
        
        // Set signing in flag to true
        isSigningIn = true
        
        // Perform asynchronous network request
        URLSession.shared.dataTask(with: request) { [weak self] data, response, error in
            DispatchQueue.main.async {
                if let error = error {
                    print("Error: \(error.localizedDescription)")
                    self?.hasError = true
                } else if let httpResponse = response as? HTTPURLResponse, httpResponse.statusCode != 200 {
                    print("HTTP Error: \(httpResponse.statusCode)")
                    self?.hasError = true
                } else if let data = data {
                    // Decode and handle the response
                    do {
                        let signInResponse = try JSONDecoder().decode(SignInResponse.self, from: data)
                        print("Sign In Response: \(signInResponse)")
                        // Perform further actions with signInResponse.accessToken
                    } catch {
                        print("Unable to Decode Response: \(error)")
                        self?.hasError = true
                    }
                }
                // Set signing in flag to false after completing the request
                self?.isSigningIn = false
            }
        }.resume()
    }
}

// Private structure to decode sign-in API response
fileprivate struct SignInResponse: Decodable {
    let accessToken: String
}
``` -->

### Explanation

#### Properties

- **@Published variables**: These properties are used for reactive UI updates, allowing the view to update automatically based on changes to `email`, `password`, `hasError`, and `isSigningIn`.
  
- **canSignIn**: This computed property checks if both `email` and `password` are not empty, enabling the sign-in button or action.

#### Methods

- **signIn()**: Initiates the sign-in process by constructing a `URLRequest` to the API endpoint (`https://api.cheer-supports.com/api/v1/liver/login`). It performs Basic Authentication using the provided `email` and `password`. Upon receiving the response, it checks for errors and decodes the JSON response using `JSONDecoder`. If successful, it prints the `accessToken` from `SignInResponse`.

#### Network Request Handling

- The network request (`URLSession.shared.dataTask`) is performed asynchronously. Upon completion:
  - If there's an `error` during the request or the HTTP status code is not 200, `hasError` is set to `true`.
  - If the response data is received successfully, it attempts to decode it into the `SignInResponse` structure. Errors during decoding also set `hasError` to `true`.
  
#### Error Handling

- Errors are handled both at the network request level and during JSON decoding. They are printed to the console for debugging purposes and set `hasError` to `true` to indicate a failed sign-in attempt.

### Usage

#### Integration in SwiftUI Views

You can integrate `SignInViewModel` into your SwiftUI views as follows:

```swift
struct SignInView: View {
    @StateObject private var signInViewModel = SignInViewModel()
    
    var body: some View {
        VStack {
            TextField("Email", text: $signInViewModel.email)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            
            SecureField("Password", text: $signInViewModel.password)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            
            Button(action: {
                signInViewModel.signIn()
            }) {
                Text("Sign In")
            }
            .disabled(!signInViewModel.canSignIn)
            .padding()
            
            if signInViewModel.hasError {
                Text("Sign In Failed")
                    .foregroundColor(.red)
            }
            
            if signInViewModel.isSigningIn {
                ProgressView()
            }
        }
        .padding()
    }
}
```

#### Example

In your SwiftUI view, bind the text fields to `email` and `password`, enable the sign-in button based on `canSignIn`, and handle UI updates based on `hasError` and `isSigningIn`.

### Conclusion

The `SignInViewModel` class encapsulates the logic for signing in users through an API endpoint using Basic Authentication. It provides reactive properties for seamless integration with SwiftUI views, ensuring a smooth user experience while handling network requests and error conditions effectively.

This documentation guides you through integrating and understanding the `SignInViewModel` class within your SwiftUI-based application for managing user sign-in functionality.