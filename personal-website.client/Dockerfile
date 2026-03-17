FROM node:24-alpine AS build

WORKDIR /app

COPY package*.json ./
RUN npm install -g @angular/cli
RUN npm install

COPY . .
RUN ng build --configuration production


FROM nginx:alpine AS final

COPY ./cert/nginx-selfsigned.* /etc/nginx/ssl/
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/dist/personal-website.client/browser /etc/nginx/html

EXPOSE 4200
CMD ["nginx", "-g", "daemon off;"]