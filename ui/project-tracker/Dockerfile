FROM nginx AS base 
WORKDIR /usr/share/nginx/html
EXPOSE 80
EXPOSE 443

FROM node:16 AS build
WORKDIR /src
COPY ["package.json", "."]
COPY ["yarn.lock", "."]
RUN yarn install
COPY . .
RUN yarn build

FROM build AS publish
RUN yarn export

FROM base AS final
COPY --from=publish /src/out .