FROM node:alpine as build-stage
WORKDIR /app
COPY Web/SPA/package*.json /app
RUN npm install
COPY Web/SPA/ /app
RUN npm run build

FROM nginx:alpine
WORKDIR /var/www/
RUN rm -rf ./*
COPY --from=build-stage /app/build .