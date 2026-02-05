FROM node:24-alpine as build
WORKDIR /app
EXPOSE 4200
# Copy package-related files first to leverage Docker's caching mechanism
COPY package.json ./
RUN npm install

RUN npm install -g @angular/cli

COPY . .
RUN ng build --configuration production

FROM nginx:alpine

# # Use a built-in non-root user for security best practices
# #USER nginx

# # Copy the static build output from the build stage to Nginx's default HTML serving directory
COPY --from=build /app/dist/*/browser /usr/share/nginx/html

# # Expose port 80 to allow HTTP traffic
EXPOSE 80
CMD ["nginx","-g","daemon off;"]