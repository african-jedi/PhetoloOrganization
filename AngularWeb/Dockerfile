FROM node:24-alpine as build
WORKDIR /app
EXPOSE 4200
# Copy package-related files first to leverage Docker's caching mechanism
COPY package.json ./

RUN npm install -g @angular/cli

#RUN --mount=type=cache,target=/root/.npm npm ci

COPY . .

RUN npm install

# Build the Angular application
CMD ["ng", "serve", "--host", "0.0.0.0", "--configuration", "production"]

# FROM nginx:latest

# # Use a built-in non-root user for security best practices
# #USER nginx

# # Copy the static build output from the build stage to Nginx's default HTML serving directory
# COPY --chown=nginx:nginx --from=build /app/dist/*/browser /usr/share/nginx/html

# # Expose port 8080 to allow HTTP traffic
# # Note: The default NGINX container now listens on port 8080 instead of 80 
# EXPOSE 8080

# # Start Nginx directly with custom config
