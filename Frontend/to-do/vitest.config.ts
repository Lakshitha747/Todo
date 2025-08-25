// vite.config.ts or vitest.config.ts
import { defineConfig } from 'vitest/config';

export default defineConfig({
  test: {
    globals: true, // Recommended to use Vitest's global API for simplicity
    environment: 'jsdom',
    setupFiles: ['./src/setupTests.ts'],
  },
});