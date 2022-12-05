FROM node:lts-alpine

# Set working directory
WORKDIR /app

# Copy all files
COPY . .


# Build app
RUN yarn install

# Build app
RUN yarn build

# Remove src directory
RUN rm -rf src

# Install PM2 globally
RUN npm install --global pm2

ENV NODE_ENV production

# Run container as non-root (unprivileged) user
RUN addgroup -g 1001 -S nodejs
RUN adduser -S nextjs -u 1001

# Folder "/cache/images" is created automatically first time the app is accessed
# this results in permission denied error, so we need to create the folder earlier on our own
RUN mkdir -p .next/cache/images && chown nextjs:nodejs .next/cache/images

USER nextjs

# Expose the listening port
EXPOSE 3000

# Launch app with PM2
CMD [ "pm2-runtime", "start", "yarn", "--interpreter", "sh", "--", "start" ]