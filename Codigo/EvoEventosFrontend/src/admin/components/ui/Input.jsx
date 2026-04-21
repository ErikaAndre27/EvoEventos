import { Search } from 'lucide-react'

export default function Input({ icon = 'search', ...props }) {
  return (
    <label className="ad-input">
      {icon === 'search' ? <Search size={16} /> : null}
      <input {...props} />
    </label>
  )
}
