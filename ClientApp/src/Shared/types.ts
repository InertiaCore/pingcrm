/**
 * Shared TypeScript types for Vue components
 */

import type { Placement } from '@popperjs/core'

// Dropdown component types
export interface DropdownProps {
  placement?: Placement
  autoClose?: boolean
}

// SearchFilter component types
export interface SearchFilterProps {
  modelValue?: string | null
  maxWidth?: number
}

// Icon component types
export type IconName = 'cheveron-down' | 'cheveron-right' | 'dashboard' | 'office' | 'printer' | 'trash' | 'users'

export interface IconProps {
  name: IconName
  iconClass?: string | string[] | Record<string, boolean>
}

// Add more shared component types as needed...