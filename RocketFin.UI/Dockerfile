
FROM node:18-alpine

WORKDIR /app-react

EXPOSE 3000

COPY public/ /app-react/public
COPY src/ /app-react/src
COPY package.json /app-react/
COPY package-lock.json /app-react/
COPY tsconfig.json /app-react/
COPY .env /app-react/

RUN npm install
RUN npm install react-scripts@3.4.1 -g --silent



CMD ["npm", "start"]


