# Test

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 20.3.7.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Starting App using SSL

To start a local development server using ssl certificate, run:

```bash
ng serve --ssl true --ssl-cert "./server.crt" --ssl-key "./server.key"
```

## Trust Certificate
* Double click server.crt
* Select the login keychain in Keychain Access
* You should see an entry called localhost - double click that
* Expand the 'Trust' section and select 'Always Trust' under 'When using this certificate'
* This step may be optional: Save the changes by adding your password 

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

For generating a component without Tests
```bash
ng g c ComponentTips --skip-tests=false
```

For generating a serive
```bash
ng g s service/shared
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Karma](https://karma-runner.github.io) test runner, use the following command:

```bash
ng test
```

## Running only 1 spec that has issue
Use the below command with "--watch=true" to view on the browser.

```bash
ng test --include='src/app/service/sharedservice.spec.ts' --watch=true
```

## Running unit tests with code coverage

To execute unit tests with code coverage, use the following command:

```bash
ng test --no-watch --code-coverage
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.
