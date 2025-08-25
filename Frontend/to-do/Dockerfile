# ---------- Build stage ----------
FROM node:20-alpine AS build
WORKDIR /app
COPY package*.json ./
# If you have pnpm/yarn, swap the install command accordingly
RUN npm ci
COPY . .
# If your Vite app needs a base URL, set it via env or vite.config.*.
RUN npm run build

# ---------- Runtime stage ----------
FROM nginx:alpine
# Nginx will serve the built assets
COPY --from=build /app/dist /usr/share/nginx/html

# Provide a SPA-friendly config (history fallback)
COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 5173
CMD ["nginx", "-g", "daemon off;"]
