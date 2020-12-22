FROM node:12.8-alpine AS builder
COPY . ./LeagueDraft-Spa
WORKDIR /LeagueDraft-Spa
RUN npm i
RUN $(npm bin)/ng build --prod

FROM nginx:1.15.8-alpine
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=builder /LeagueDraft-Spa/dist/LeagueDraft-SPA /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]